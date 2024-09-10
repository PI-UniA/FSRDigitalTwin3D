using AasCore.Aas3_0;
using AdminShellNS.Models;

namespace FSR.DigitalTwin.App.Interfaces.Services;

public interface IDigitalTwinOperationalService {
    Task<ExecutionState> InvokeAsync(IOperation operation, int? timestamp, string requestId, string submodelId, string? handleId = null);
    Task<OperationResult> GetResultAsync(string requestId);
    Task<ExecutionState> GetExecutionStateAsync(string requestId);
}