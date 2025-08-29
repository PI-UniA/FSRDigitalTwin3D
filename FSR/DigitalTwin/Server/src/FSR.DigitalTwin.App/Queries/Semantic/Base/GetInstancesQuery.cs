namespace FSR.DigitalTwin.App.Queries.Semantic.Base;

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.SharedKernel;
using VDS.RDF;

public class GetInstancesQuery : ISparqlQuery<IEnumerable<INode>>
{
    private readonly ISparqlServer? _sparqlServer;
    private readonly Uri _typeUri;

    public string Query => SparqlHelper.LoadQuery("../FSR.DigitalTwin.App/Sparql/GetInstances.sparql", [_typeUri.ToString()]);
    public ISparqlResponseParser Parser => new ResponseParser() { Type = _typeUri };
    public ISparqlServer SparqlServer { get => _sparqlServer ?? throw new NullReferenceException(); init => _sparqlServer = value; }

    public GetInstancesQuery(Uri typeUri)
    {
        _typeUri = typeUri;
    }

    private class ResponseParser : ISparqlResponseParser
    {
        public required Uri Type { init; get; }

        public IEnumerable<Triple> FromJson(string jsonResponse)
        {
            var json = JsonDocument.Parse(jsonResponse);
            var bindings = json.RootElement.GetProperty("results").GetProperty("bindings");

            var triples = new List<Triple>();
            foreach (var binding in bindings.EnumerateArray())
            {
                if (!binding.TryGetProperty("instance", out JsonElement instance_))
                    continue;
                var instance = RdfNodeFactory.CreateFromJson(instance_);
                triples.Add(new Triple(instance, UriPrefix.RDF | "type", new UriNode(Type)));
            }
            return triples;
        }
    }

    public async Task<Result<IEnumerable<INode>>> RunAsync(CancellationToken cancellationToken = default)
    {
        var response = await SparqlServer.QueryAsync(this, cancellationToken);
        if (response.IsFailure)
        {
            return Result.Failure<IEnumerable<INode>>(response.Error);
        }
        return Result.Success(response.Value.Select(t => t.Subject).Distinct());
    }

    public Result<IEnumerable<INode>> Run()
    {
        var response = SparqlServer.Query(this);
        if (response.IsFailure)
        {
            return Result.Failure<IEnumerable<INode>>(response.Error);
        }
        return Result.Success(response.Value.Select(t => t.Subject).Distinct());
    }
}