namespace FSR.DigitalTwin.App.Interfaces.Services.Semantic;

public interface IOwlOntologyService {
    
    bool Empty => IsEmpty();
    int Count => CountTriples();

    Task<bool> IsEmptyAsync(CancellationToken cancellationToken = default);
    bool IsEmpty();
    Task<int> CountTriplesAsync(CancellationToken cancellationToken = default);
    int CountTriples();
    Task<bool> CreateOntologyAsync(CancellationToken cancellationToken = default);
    Task<bool> CreateOntologyFromFileAsync(string filePath, string format = "text/turtle", CancellationToken cancellationToken = default);
    Task<bool> DeleteOntologyAsync(CancellationToken cancellationToken = default);

}