using FSR.DigitalTwin.App.Common.Semantic;
using FSR.DigitalTwin.App.Interfaces.Services.Semantic;
using FSR.DigitalTwin.Domain.SharedKernel;
using Microsoft.Extensions.Logging;

namespace FSR.DigitalTwin.App.Services.Semantic;

public class OwlOntologyService : IOwlOntologyService
{
    private readonly ISemanticDataRepository _semanticDataRepository;
    private readonly ILogger<OwlOntologyService> _logger;

    public OwlOntologyService(ISemanticDataRepository semanticDataRepository, ILogger<OwlOntologyService> logger) {
        _semanticDataRepository = semanticDataRepository ?? throw new ArgumentNullException(nameof(semanticDataRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<Result<bool>> CreateOntologyAsync()
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
                await _semanticDataRepository.LoadFileAsync(filePath);
            }
            catch (Exception ex)
            {
                return Result.Failure<bool>(ex.Message);
            }
        }

        return true;
    }
}