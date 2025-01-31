using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Interfaces.Services.Semantic;
using FSR.DigitalTwin.App.Queries.Semantic.Base;
using FSR.DigitalTwin.Domain.SharedKernel;
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

    public async Task<Result<bool>> CreateOntologyAsync(CancellationToken cancellationToken = default)
    {
        GetTripleCountQuery tripleCountQuery = new(_sparqlServer);
        var tripleCountQueryResponse = await tripleCountQuery.RunAsync(cancellationToken); 
        if (tripleCountQueryResponse.Value > 0) {
            return false;
        }

        string projectDirectory = Directory.GetCurrentDirectory();
        string fullPath = Path.Combine(projectDirectory, "owl");

        if (!Directory.Exists(fullPath))
        {
            return Result.Failure<bool>($"Directory not found: {fullPath}");
        }

        foreach (var filePath in Directory.GetFiles(fullPath, "*.ttl"))
        {
            try
            {
                await _tripletServer.LoadFileAsync(filePath);
            }
            catch (Exception ex)
            {
                return Result.Failure<bool>(ex.Message);
            }
        }

        return true;
    }
}