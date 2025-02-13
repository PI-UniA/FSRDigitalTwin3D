using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.SharedKernel;
using VDS.RDF;
using VDS.RDF.Query;

namespace FSR.DigitalTwin.App.Queries.Semantic.Base;

public abstract class SparqlQueryCommand<T> : ISparqlQuery<T>
{
    private SparqlQuery _sparqlQuery;
    private ISparqlServer _sparqlServer;

    public SparqlQueryCommand(SparqlQuery sparqlQuery, ISparqlServer sparqlServer) {
        _sparqlQuery = sparqlQuery ?? throw new NullReferenceException(nameof(sparqlQuery));
        _sparqlServer = sparqlServer ?? throw new NullReferenceException(nameof(sparqlServer));
    }

    public string Query => _sparqlQuery.ToString();
    public abstract ISparqlResponseParser Parser { get; }
    public ISparqlServer SparqlServer { init => _sparqlServer = value; get => _sparqlServer; }
    protected abstract T GetQueryResult(IEnumerable<Triple> triples);

    public Result<T> Run() {
        var result = SparqlServer.Query(this);
        if (result.IsFailure) {
            return Result.Failure<T>($"Failed to run Sparql Query: {Query} .");
        }
        return GetQueryResult(result.Value);
    }

    public async Task<Result<T>> RunAsync(CancellationToken cancellationToken = default) {
        var result = await SparqlServer.QueryAsync(this);
        if (result.IsFailure) {
            return Result.Failure<T>($"Failed to run Sparql Query: {Query} .");
        }
        return GetQueryResult(result.Value);
    }

}