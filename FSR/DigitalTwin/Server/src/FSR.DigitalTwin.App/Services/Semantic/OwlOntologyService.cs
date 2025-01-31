using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Interfaces.Services.Semantic;
using FSR.DigitalTwin.App.Queries.Semantic.Base;
using Microsoft.Extensions.Logging;

namespace FSR.DigitalTwin.App.Services.Semantic;

public class OwlOntologyService : IOwlOntologyService
{
    private readonly ITripletServer _tripletServer;
    private readonly ISparqlServer _sparqlServer;
    private readonly ILogger<OwlOntologyService> _logger;

    public OwlOntologyService(ITripletServer tripletServer, ISparqlServer sparqlServer, ILogger<OwlOntologyService> logger) {
        _tripletServer = tripletServer ?? throw new ArgumentNullException(nameof(tripletServer));
        _sparqlServer = sparqlServer ?? throw new ArgumentNullException(nameof(sparqlServer));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<bool> CreateOntologyAsync(CancellationToken cancellationToken = default)
    {
        string projectDirectory = Directory.GetCurrentDirectory();
        string fullPath = Path.Combine(projectDirectory, "owl");

        if (!Directory.Exists(fullPath))
        {
            _logger.LogError("Directory not found: {FullPath}", fullPath);
            return false;
        }

        foreach (var filePath in Directory.GetFiles(fullPath, "*.ttl"))
        {
            var result = await _tripletServer.LoadFileAsync(filePath, "text/turtle", cancellationToken);
            if (result.IsFailure) {
                _logger.LogError("Failed to load OWL file: {FilePath}", filePath);
                return false;
            }
        }

        return true;
    }

    public async Task<bool> CreateOntologyFromFileAsync(string filePath, string format = "text/turtle", CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
        {
            _logger.LogError("File not found: {FilePath}", filePath);
            return false;
        }
        var result = await _tripletServer.LoadFileAsync(filePath, format, cancellationToken);
        return result.IsSuccess;
    }

    public async Task<bool> IsEmptyAsync(CancellationToken cancellationToken = default)
    {
        GetTripleCountQuery tripleCountQuery = new(_sparqlServer);
        var tripleCountQueryResponse = await tripleCountQuery.RunAsync(cancellationToken); 
        return tripleCountQueryResponse.IsFailure || tripleCountQueryResponse.Value == 0;
    }

    public bool IsEmpty() {
        GetTripleCountQuery tripleCountQuery = new(_sparqlServer);
        var tripleCountQueryResponse = tripleCountQuery.Run(); 
        return tripleCountQueryResponse.IsFailure || tripleCountQueryResponse.Value == 0;
    }
}