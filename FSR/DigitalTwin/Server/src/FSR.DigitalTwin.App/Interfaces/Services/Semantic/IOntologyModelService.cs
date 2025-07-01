namespace FSR.DigitalTwin.App.Interfaces.Services.Semantic;

public interface IOntologyModelService {
    
    bool Empty => IsEmpty();
    int Count => CountTriples();

    Task<bool> IsEmptyAsync(CancellationToken cancellationToken = default);
    bool IsEmpty();
    Task<int> CountTriplesAsync(CancellationToken cancellationToken = default);
    int CountTriples();

    Task<bool> LoadOntologyModelAsync(string ontoFile, OntologyModelFileFormat ontoFormat = OntologyModelFileFormat.DEFAULT, CancellationToken cancellationToken = default);
    Task<bool> DeleteOntologyModelAsync(CancellationToken cancellationToken = default);
}

public enum OntologyModelFileFormat {
    DEFAULT = 0,
    TURTLE = 1,
    RDF_XML = 2
}