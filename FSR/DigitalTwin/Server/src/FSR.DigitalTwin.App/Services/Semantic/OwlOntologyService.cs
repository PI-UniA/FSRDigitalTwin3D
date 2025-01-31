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
                await _tripletServer.LoadFileAsync(filePath, "text/turtle", cancellationToken);
            }
            catch (Exception ex)
            {
                return Result.Failure<bool>(ex.Message);
            }
        }

        return true;
    }

    public async Task<Result<bool>> CreateOntologyFromFileAsync(string filePath, string format = "text/turtle", CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
        {
            return Result.Failure<bool>($"File not found: {filePath}");
        }
        try
        {
            await _tripletServer.LoadFileAsync(filePath, format, cancellationToken);
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(ex.Message);
        }
        return true;
    }

    public async Task<Result<bool>> IsEmptyAsync(CancellationToken cancellationToken = default)
    {
        GetTripleCountQuery tripleCountQuery = new(_sparqlServer);
        var tripleCountQueryResponse = await tripleCountQuery.RunAsync(cancellationToken); 
        return tripleCountQueryResponse.Value == 0;
    }

    public Result<bool> IsEmpty() {
        return IsEmptyAsync().Result;
    }
}