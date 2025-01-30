using System.Diagnostics.Metrics;
using System.Text.Json;
using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.SharedKernel;
using Namotion.Reflection;
using VDS.RDF;

namespace FSR.DigitalTwin.App.Queries.Semantic.Base;

public class GetTripleCountQuery : ISparqlQuery<int>
{
    public string Query => "SELECT COUNT(*) WHERE { ?s ?p ?o . }";
    public ISparqlResponseParser Parser => new ResponseParser();
    public ISparqlServer SparqlServer { get; init; }

    public GetTripleCountQuery(ISparqlServer sparqlServer) {
        SparqlServer = sparqlServer;
    }

    private class ResponseParser : ISparqlResponseParser
    {
        public IEnumerable<Triple> FromJson(string jsonResponse)
        {
            var json = JsonDocument.Parse(jsonResponse);
            var bindings = json.RootElement.GetProperty("results").GetProperty("bindings");
            return bindings.EnumerateArray().Select(b => {
                string n = b.GetProperty(".1").GetProperty("value").GetString() ?? throw new FormatException();
                return new Triple(new BlankNode(".1"), new UriNode(new Uri("rdf:value")), new LiteralNode(n));
            });
        }
    }

    public async Task<Result<int>> RunAsync(CancellationToken cancellationToken = default)
    {
        var response = await SparqlServer.QueryAsync(this);
        var triple = response.Value.First();
        var literal = triple.Object as LiteralNode ?? throw new FormatException();
        return int.Parse(literal.Value);
    }

    public Result<int> Run()
    {
        var response = SparqlServer.Query(this);
        var triple = response.Value.First();
        var literal = triple.Object as LiteralNode ?? throw new FormatException();
        return int.Parse(literal.Value);
    }
}