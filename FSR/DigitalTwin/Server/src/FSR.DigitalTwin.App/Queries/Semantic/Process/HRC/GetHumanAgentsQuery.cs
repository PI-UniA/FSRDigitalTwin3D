using System.Text.Json;
using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.Model.Process.HRC.Agent;
using FSR.DigitalTwin.Domain.SharedKernel;
using VDS.RDF;
using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.App.Queries.Semantic.Process.HRC;

public class GetHumanAgentsQuery : ISparqlQuery<IEnumerable<Human>>
{
    public string Query => KnownPrefix.GetSparql() +
@"
SELECT DISTINCT ?human ?name ?embodidment
WHERE {
    ?human rdf:type soho:Human .
    OPTIONAL { 
        ?human soho:hasEmbodiment ?embodidment . 
        ?embodidment rdf:type soho:ProductionObject . 
    }
    OPTIONAL { ?human rdfs:label ?name . }
}
";

    public ISparqlResponseParser Parser => new ResponseParser();
    public ISparqlServer SparqlServer { get => _sparqlServer ?? throw new NullReferenceException(); init => _sparqlServer = value; }
    private readonly ISparqlServer? _sparqlServer;

    private static readonly BaseNode _hasEmbodiement = new UriNode(new Uri(KnownPrefix.SOHO + "hasEmbodiment"));
    private static readonly BaseNode _label = new UriNode(new Uri(KnownPrefix.RDFS + "label"));
    private static readonly BaseNode _type = new UriNode(new Uri(KnownPrefix.RDF + "type"));
    private static readonly BaseNode _human = new UriNode(new Uri(KnownPrefix.SOHO + "Human"));
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
                if (!binding.TryGetProperty("human", out JsonElement human_))
                    continue;
                var human = RdfNodeFactory.CreateFromJson(human_);
                triples.Add(new Triple(human, _type, _human));
                if (binding.TryGetProperty("name", out JsonElement name_))
                {
                    var name = RdfNodeFactory.CreateFromJson(name_);
                    triples.Add(new Triple(human, _label, name));
                }
                if (binding.TryGetProperty("embodiment", out JsonElement embodiment_))
                {
                    var embodiment = RdfNodeFactory.CreateFromJson(embodiment_);
                    triples.Add(new Triple(human, _type, _human));
                    triples.Add(new Triple(embodiment, _type, _productionObject));
                }
            }

            return triples;
        }
    }

    private static IEnumerable<Human> GetHumans(OntologyGraph graph)
    {
        return graph.Triples
            .Where(t => t.Predicate as BaseNode == _type && t.Object as BaseNode == _human)
            .Distinct()
            .Select(x =>
            {
                var resource = graph.CreateIndividual(x.Subject);
                var embodiments = graph.Triples
                    .Where(t => t.Subject as BaseNode == x.Subject as BaseNode && t.Predicate as BaseNode == _hasEmbodiement)
                    .Select(t => graph.CreateIndividual(t.Object));
                var human = new Human(resource) { Resource = resource };
                human.Embodyments.AddRange(embodiments);
                return human;
            });
    }

    public Result<IEnumerable<Human>> Run()
    {
        var response = SparqlServer.Query(this);
        if (response.IsFailure)
        {
            return Result.Failure<IEnumerable<Human>>(response.Error);
        }
        OntologyGraph graph = new();
        foreach (Triple triple in response.Value)
        {
            graph.Assert(triple);
        }
        return Result.Success(GetHumans(graph));
    }

    public async Task<Result<IEnumerable<Human>>> RunAsync(CancellationToken cancellationToken = default)
    {
        var response = await SparqlServer.QueryAsync(this);
        if (response.IsFailure)
        {
            return Result.Failure<IEnumerable<Human>>(response.Error);
        }
        OntologyGraph graph = new();
        foreach (Triple triple in response.Value)
        {
            graph.Assert(triple);
        }
        return Result.Success(GetHumans(graph));
    }
}