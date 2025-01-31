using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Interfaces.Services.Dummy;
using FSR.DigitalTwin.App.Queries.Semantic.Base;
using Microsoft.Extensions.Logging;
using VDS.RDF;

namespace FSR.DigitalTwin.App.Services.Dummy;

public class DummySemanticDataService : IDummySemanticDataService
{
    private readonly ISparqlServer _sparqlServer;
    private readonly ITripletServer _tripletServer;
    private readonly ILogger<IDummySemanticDataService> _logger;

    public DummySemanticDataService(ISparqlServer sparqlServer, ITripletServer tripletServer, ILogger<DummySemanticDataService> logger) {
        _sparqlServer = sparqlServer ?? throw new ArgumentNullException(nameof(sparqlServer));
        _tripletServer = tripletServer ?? throw new ArgumentNullException(nameof(tripletServer));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task PushDataAsync(string s, string p, string o)
    {
        await _tripletServer.AddAsync(s, p, o);
    }

    public async Task RunExampleQueriesAsync()
    {
        GetAllTripletsQuery query = new(_sparqlServer);
        var result = await query.RunAsync();
        foreach (Triple triple in result.Value.Take(10)) {
            _logger.LogInformation("Found triple: {Triple}", triple);
        }

        GetTripleCountQuery query1 = new(_sparqlServer);
        var n = await query1.RunAsync();
        _logger.LogInformation("Semantic repo triple count: {N}", n.Value);
    }
}