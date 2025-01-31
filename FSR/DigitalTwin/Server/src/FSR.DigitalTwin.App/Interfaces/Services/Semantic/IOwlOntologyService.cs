namespace FSR.DigitalTwin.App.Interfaces.Services.Semantic;

public interface IOwlOntologyService {
    
    Task<bool> IsEmptyAsync(CancellationToken cancellationToken = default);
    bool IsEmpty();
    Task<bool> CreateOntologyAsync(CancellationToken cancellationToken = default);
    Task<bool> CreateOntologyFromFileAsync(string filePath, string format = "text/turtle", CancellationToken cancellationToken = default);

}