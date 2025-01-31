using FSR.DigitalTwin.Domain.SharedKernel;

namespace FSR.DigitalTwin.App.Interfaces.Services.Semantic;

public interface IOwlOntologyService {
    
    Task<Result<bool>> IsEmptyAsync(CancellationToken cancellationToken = default);
    Result<bool> IsEmpty();
    Task<Result<bool>> CreateOntologyAsync(CancellationToken cancellationToken = default);
    Task<Result<bool>> CreateOntologyFromFileAsync(string filePath, string format = "text/turtle", CancellationToken cancellationToken = default);

}