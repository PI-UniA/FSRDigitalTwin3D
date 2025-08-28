using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Common.Utils.Semantic;
using FSR.DigitalTwin.App.Interfaces.Queries.Semantic;
using FSR.DigitalTwin.Domain.Model.Process.HRC.Task;
using FSR.DigitalTwin.Domain.SharedKernel;
using VDS.RDF;

namespace FSR.DigitalTwin.App.Queries.Semantic.Process.HRC;

public class GetFunctionPropertyDataQuery : ISparqlQuery<IEnumerable<FunctionData>>
{
    private readonly ISparqlServer? _sparqlServer;
    private readonly Uri _functionUri;

    // TODO Use config paths!
    public string Query => SparqlHelper.LoadQuery("../FSR.DigitalTwin.App/Sparql/GetFunctionPropertyData.sparql", [_functionUri.ToString()]);
    public ISparqlResponseParser Parser => new ResponseParser() { Function = _functionUri };
    public ISparqlServer SparqlServer { get => _sparqlServer ?? throw new NullReferenceException(); init => _sparqlServer = value; }

    public GetFunctionPropertyDataQuery(Uri functionUri)
    {
        _functionUri = functionUri;
    }

    private class ResponseParser : ISparqlResponseParser
    {
        public required Uri Function { init; get; }

        public IEnumerable<Triple> FromJson(string jsonResponse)
        {
            throw new NotImplementedException();
        }
    }

    public Result<IEnumerable<FunctionData>> Run()
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<FunctionData>>> RunAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}