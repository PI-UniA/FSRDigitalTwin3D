using System.Text.Json;
using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.Model.Process.HRC.Agent;
using FSR.DigitalTwin.Domain.SharedKernel;
using Namotion.Reflection;
using VDS.RDF;
using VDS.RDF.Ontology;

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
        var individuals = graph.Triples
            .Select(t => t.Subject)
            .Distinct()
            .Select(x => new Individual(x, graph));
        var names = individuals
            .Select(x => x.GetResourceProperty(KnownPrefix.RDFS + "label"))
            .First();
        // var embodidments = individuals
        //     .Select(x => x.GetResourceProperty(KnownPrefix.SOHO + "hasEmbodiment"));
        return Result.Failure<IEnumerable<Cobot>>("Work in progress...");
    }

    public Task<Result<IEnumerable<Cobot>>> RunAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}