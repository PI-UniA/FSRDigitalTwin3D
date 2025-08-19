using System.Diagnostics;
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
        SELECT DISTINCT ?robot ?name ?embodiment
        WHERE {
            ?robot rdf:type soho:Cobot .
            OPTIONAL { 
                ?robot soho:hasEmbodiment ?embodiment . 
                ?embodiment rdf:type soho:ProductionObject . 
            }
            OPTIONAL { ?robot rdfs:label ?name . }
        }
        ";

    public ISparqlResponseParser Parser => new ResponseParser();
    public ISparqlServer SparqlServer { get => _sparqlServer ?? throw new NullReferenceException(); init => _sparqlServer = value; }
    private readonly ISparqlServer? _sparqlServer;

    private static readonly BaseNode _hasEmbodiement = new UriNode(new Uri(KnownPrefix.SOHO + "hasEmbodiment"));
    private static readonly BaseNode _label = new UriNode(new Uri(KnownPrefix.RDFS + "label"));
    private static readonly BaseNode _type = new UriNode(new Uri(KnownPrefix.RDF + "type"));
    private static readonly BaseNode _cobot = new UriNode(new Uri(KnownPrefix.SOHO + "Cobot"));
    private static readonly BaseNode _productionObject = new UriNode(new Uri(KnownPrefix.SOHO + "ProductionObject"));

    private class ResponseParser : ISparqlResponseParser
    {
        public IEnumerable<Triple> FromJson(string jsonResponse)
        {
            var json = JsonDocument.Parse(jsonResponse);
            var bindings = json.RootElement.GetProperty("results").GetProperty("bindings");

            var triples = new List<Triple>();
            foreach (var binding in bindings.EnumerateArray())
            {
                if (!binding.TryGetProperty("robot", out JsonElement robot_))
                    continue;
                var robot = RdfNodeFactory.CreateFromJson(robot_);
                triples.Add(new Triple(robot, _type, _cobot));
                if (binding.TryGetProperty("name", out JsonElement name_))
                {
                    var name = RdfNodeFactory.CreateFromJson(name_);
                    triples.Add(new Triple(robot, _label, name));
                }
                if (binding.TryGetProperty("embodiment", out JsonElement embodiment_))
                {
                    var embodiment = RdfNodeFactory.CreateFromJson(embodiment_);
                    triples.Add(new Triple(robot, _type, _cobot));
                    triples.Add(new Triple(embodiment, _type, _productionObject));
                }
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
            .Where(t => t.Predicate as BaseNode == _type && t.Object as BaseNode == _cobot)
            .Distinct()
            .Select(x =>
            {
                var resource = new Individual(x.Subject, graph);
                var embodiments = graph.Triples
                    .Where(t => t.Subject == x.Subject && t.Predicate as BaseNode == _hasEmbodiement)
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
            .Where(t => t.Predicate as BaseNode == _type && t.Object as BaseNode == _cobot)
            .Distinct()
            .Select(x =>
            {
                var resource = new Individual(x.Subject, graph);
                var embodiments = graph.Triples
                    .Where(t => t.Subject == x.Subject && t.Predicate as BaseNode == _hasEmbodiement)
                    .Select(t => new Individual(t.Object, graph));
                var cobot = new Cobot(resource) { Resource = resource };
                cobot.Embodyments.AddRange(embodiments);
                return cobot;
            });

        return Result.Success(cobots);
    }
}