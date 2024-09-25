using AasCore.Aas3_0;
using AdminShellNS.Models;
using FSR.DigitalTwin.App.Interfaces.Services;

namespace FSR.DigitalTwin.App.Services;

public class DigitalTwinOperationalService : IDigitalTwinOperationalService
{
    public Task<ExecutionState> GetExecutionStateAsync(string handleId)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult> GetResultAsync(string requestId)
    {
        throw new NotImplementedException();
    }

    public Task<ExecutionState> InvokeAsync(IOperation operation, int? timestamp, string requestId, string submodelId, string? handleId = null)
    {
        throw new NotImplementedException();
    }

    public void SetResult(string requestId, OperationResult result)
    {
        throw new NotImplementedException();
    }

    public void UpdateExecutionState(string handleId, ExecutionState executionState)
    {
        throw new NotImplementedException();
    }
}