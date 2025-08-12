using System.Text.Json;
using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.Model.Process.HRC.Agent;
using FSR.DigitalTwin.Domain.SharedKernel;
using VDS.RDF;
using VDS.RDF.Ontology;
using VDS.RDF.Query;

namespace FSR.DigitalTwin.App.Queries.Semantic.Process.HRC;

public class GetCobotAgentsQuery : ISparqlQuery<IEnumerable<Cobot>>
{
    public string Query => KnownPrefix.GetSparql() +
        @"
        SELECT ?robot ?name ?embodidment
        WHERE {
            ?robot rdf:type soho:Human .
            OPTIONAL { ?robot soho:hasEmbodiment ?embodidment . }
            OPTIONAL { ?robot rdf:label ?name . } 
        }
        ";

    public ISparqlResponseParser Parser => new ResponseParser();
    public ISparqlServer SparqlServer { get; init; }

    public GetCobotAgentsQuery(ISparqlServer sparqlServer) {
        SparqlServer = sparqlServer;
    }

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
                var hasEmbodiment = new UriNode(new Uri(KnownPrefix.SOHO + "hasEmbodiment"));
                var label = new UriNode(new Uri(KnownPrefix.RDFS + "label"));
                triples.Add(new Triple(robot, hasEmbodiment, embodiment));
                triples.Add(new Triple(robot, label, name));
            }

            Graph graph = new();
            OntologyGraph foo = new(new Uri("foo:bar"));
            

            return triples;
        }
    }

    public Result<IEnumerable<Cobot>> Run()
    {
        return null;
    }

    public async Task<Result<IEnumerable<Cobot>>> RunAsync(CancellationToken cancellationToken = default)
    {
        return null;
    }
}