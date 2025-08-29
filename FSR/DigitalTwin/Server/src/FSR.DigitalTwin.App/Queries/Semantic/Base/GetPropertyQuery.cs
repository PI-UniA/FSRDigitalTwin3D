namespace FSR.DigitalTwin.App.Queries.Semantic.Base;

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.SharedKernel;
using VDS.RDF;

public class GetPropertyQuery : ISparqlQuery<IEnumerable<INode>>
{
    private readonly ISparqlServer? _sparqlServer;
    private readonly Uri _propertyUri;
    private readonly Uri _individualUri;

    // TODO Use config paths!
    public string Query => SparqlHelper.LoadQuery("../FSR.DigitalTwin.App/Sparql/GetProperty.sparql",
        [_propertyUri.ToString(), _individualUri.ToString()]);
    public ISparqlResponseParser Parser => new ResponseParser() { Property = _propertyUri, Individual = _individualUri };
    public ISparqlServer SparqlServer { get => _sparqlServer ?? throw new NullReferenceException(); init => _sparqlServer = value; }

    public GetPropertyQuery(Uri property, Uri individual)
    {
        _propertyUri = property;
        _individualUri = individual;
    }

    private class ResponseParser : ISparqlResponseParser
    {
        public required Uri Property { init; get; }
        public required Uri Individual { init; get; }

        public IEnumerable<Triple> FromJson(string jsonResponse)
        {
            var json = JsonDocument.Parse(jsonResponse);
            var bindings = json.RootElement.GetProperty("results").GetProperty("bindings");

            var triples = new List<Triple>();
            foreach (var binding in bindings.EnumerateArray())
            {
                if (!binding.TryGetProperty("value", out JsonElement value_))
                    continue;
                var value = RdfNodeFactory.CreateFromJson(value_);
                triples.Add(new Triple(new UriNode(Individual), new UriNode(Property), value));
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
        return Result.Success(response.Value.Select(t => t.Object));
    }

    public Result<IEnumerable<INode>> Run()
    {
        var response = SparqlServer.Query(this);
        if (response.IsFailure)
        {
            return Result.Failure<IEnumerable<INode>>(response.Error);
        }
        return Result.Success(response.Value.Select(t => t.Object));
    }
}