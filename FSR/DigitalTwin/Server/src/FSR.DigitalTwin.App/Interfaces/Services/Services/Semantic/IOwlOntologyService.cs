using FSR.DigitalTwin.Domain.SharedKernel;

namespace FSR.DigitalTwin.App.Interfaces.Services.Semantic;

public interface IOwlOntologyService {
    
    Task<Result<bool>> CreateOntologyAsync();

}