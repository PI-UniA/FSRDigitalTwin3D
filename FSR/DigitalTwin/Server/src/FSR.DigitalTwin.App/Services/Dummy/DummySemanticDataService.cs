using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Interfaces.Services.Dummy;
using FSR.DigitalTwin.App.Queries.Semantic.Base;
using Microsoft.Extensions.Logging;
using VDS.RDF;

namespace FSR.DigitalTwin.App.Services.Dummy;

public class DummySemanticDataService : IDummySemanticDataService
{
    private readonly ISemanticDataRepository _semanticDataRepository;
    private readonly ILogger<IDummySemanticDataService> _logger;

    public DummySemanticDataService(ISemanticDataRepository semanticDataRepository, ILogger<DummySemanticDataService> logger) {
        _semanticDataRepository = semanticDataRepository ?? throw new ArgumentNullException(nameof(semanticDataRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task PushDataAsync(string s, string p, string o)
    {
        await _semanticDataRepository.AddAsync(s, p, o);
    }

    public async Task RunExampleQueriesAsync()
    {
        GetAllTripletsQuery query = new(_semanticDataRepository);
        var result = await query.RunAsync();
        foreach (Triple triple in result.Value.Take(10)) {
            _logger.LogInformation("Found triple: {Triple}", triple);
        }

        GetTripleCountQuery query1 = new(_semanticDataRepository);
        var n = await query1.RunAsync();
        _logger.LogInformation("Semantic repo triple count: {N}", n.Value);
    }
}