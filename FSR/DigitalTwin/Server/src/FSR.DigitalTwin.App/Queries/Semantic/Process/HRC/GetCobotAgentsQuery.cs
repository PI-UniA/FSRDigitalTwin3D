using System.Text.Json;
using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.Model.Process.HRC.Agent;
using FSR.DigitalTwin.Domain.SharedKernel;
using VDS.RDF;
using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.App.Queries.Semantic.Process.HRC;

public class GetCobotAgentsQuery : ISparqlQuery<IEnumerable<Cobot>>
{
    public string Query => KnownPrefix.GetSparql() +
        @"
        SELECT DISTINCT ?robot ?name ?embodidment
        WHERE {
            ?robot rdf:type soho:Cobot .
            OPTIONAL { 
                ?robot soho:hasEmbodiment ?embodidment . 
                ?embodidment rdf:type soho:ProductionObject . 
            }
            OPTIONAL { ?robot rdfs:label ?name . }
        }
        ";

    public ISparqlResponseParser Parser => new ResponseParser();
    public ISparqlServer SparqlServer { get => _sparqlServer ?? throw new NullReferenceException(); init => _sparqlServer = value; }
    private readonly ISparqlServer? _sparqlServer;

    private static readonly INode _hasEmbodiement = new UriNode(new Uri(KnownPrefix.SOHO + "hasEmbodiment"));
    private static readonly INode _label = new UriNode(new Uri(KnownPrefix.RDFS + "label"));
    private static readonly INode _type = new UriNode(new Uri(KnownPrefix.RDF + "type"));
    private static readonly INode _cobot = new UriNode(new Uri(KnownPrefix.SOHO + "Cobot"));
    private static readonly INode _productionObject = new UriNode(new Uri(KnownPrefix.SOHO + "ProductionObject"));

    private class ResponseParser : ISparqlResponseParser
    {
        public IEnumerable<Triple> FromJson(string jsonResponse)
        {
            var json = JsonDocument.Parse(jsonResponse);
            var bindings = json.RootElement.GetProperty("results").GetProperty("bindings");

            var triples = new List<Triple>();
            foreach (var binding in bindings.EnumerateArray())
            {
                var robot = RdfNodeFactory.CreateFromJson(binding.GetProperty("robot"));
                var name = RdfNodeFactory.CreateFromJson(binding.GetProperty("name"));
                var embodiment = RdfNodeFactory.CreateFromJson(binding.GetProperty("embodiment"));
                triples.Add(new Triple(robot, _hasEmbodiement, embodiment));
                triples.Add(new Triple(robot, _label, name));
                triples.Add(new Triple(robot, _type, _cobot));
                triples.Add(new Triple(embodiment, _type, _productionObject));
            }

            return triples;
        }
    }

    public Result<IEnumerable<Cobot>> Run()
    {
        var response = SparqlServer.Query(this);
        if (response.IsFailure)
        {
            return Result.Failure<IEnumerable<Cobot>>(response.Error);
        }
        OntologyGraph graph = new();
        foreach (Triple triple in response.Value)
        {
            graph.Assert(triple);
        }

        var cobots = graph.Triples
            .Where(t => t.Predicate == _type && t.Object == _cobot)
            .Distinct()
            .Select(x =>
            {
                var resource = new Individual(x.Subject, graph);
                // var name = cobot.GetResourceProperty(KnownPrefix.RDFS + "label").First().ToSafeString();
                var embodiments = graph.Triples
                    .Where(t => t.Subject == x.Subject && t.Predicate == _hasEmbodiement)
                    .Select(t => new Individual(t.Object, graph));
                var cobot = new Cobot(resource) { Resource = resource };
                cobot.Embodyments.AddRange(embodiments);
                return cobot;
            });

        return Result.Success(cobots);
    }

    public async Task<Result<IEnumerable<Cobot>>> RunAsync(CancellationToken cancellationToken = default)
    {
        var response = await SparqlServer.QueryAsync(this);
        if (response.IsFailure)
        {
            return Result.Failure<IEnumerable<Cobot>>(response.Error);
        }
        OntologyGraph graph = new();
        foreach (Triple triple in response.Value)
        {
            graph.Assert(triple);
        }

        var cobots = graph.Triples
            .Where(t => t.Predicate == _type && t.Object == _cobot)
            .Distinct()
            .Select(x =>
            {
                var resource = new Individual(x.Subject, graph);
                // var name = cobot.GetResourceProperty(KnownPrefix.RDFS + "label").First().ToSafeString();
                var embodiments = graph.Triples
                    .Where(t => t.Subject == x.Subject && t.Predicate == _hasEmbodiement)
                    .Select(t => new Individual(t.Object, graph));
                var cobot = new Cobot(resource) { Resource = resource };
                cobot.Embodyments.AddRange(embodiments);
                return cobot;
            });

        return Result.Success(cobots);
    }
}