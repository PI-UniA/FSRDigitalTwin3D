using AasCore.Aas3_0;
using AasxServerStandardBib.Logging;
using AdminShellNS.Models;
using AutoMapper;
using FSR.DigitalTwin.App.GRPC.Services.DigitalTwinClientConnectionService;
using FSR.DigitalTwin.App.Interfaces.Services;
using Grpc.Core;

namespace FSR.DigitalTwin.App.GRPC.Services.RPC;

public class DigitalTwinClientConnectionRpcService : DigitalTwinClientConnectionService.DigitalTwinClientConnectionService.DigitalTwinClientConnectionServiceBase {
    
    private readonly IAppLogger<DigitalTwinClientConnectionRpcService> _logger;
    private readonly IMapper _mapper;
    private readonly IDigitalTwinClientConnectionService _connectionService;
    private readonly IDigitalTwinOperationalService _operationalService;

    public DigitalTwinClientConnectionRpcService(IAppLogger<DigitalTwinClientConnectionRpcService> logger, IMapper mapper, IDigitalTwinClientConnectionService connectionService, IDigitalTwinOperationalService operationalService) {
        _logger = logger ?? throw new NullReferenceException();
        _mapper = mapper ?? throw new NullReferenceException();
        _connectionService = connectionService ?? throw new NullReferenceException();
        _operationalService = operationalService ?? throw new NullReferenceException();
    }

    public override async Task Connect(IAsyncStreamReader<ServerNotification> requestStream, IServerStreamWriter<ClientNotification> responseStream, ServerCallContext context)
    {
        string? clientId = null;
        while (await requestStream.MoveNext()) {
            ServerNotification notification = requestStream.Current;
            ClientNotification response = new();

            switch (notification.Type) {
                case ServerNotificationType.Connect:
                    response.Type = ClientNotificationType.Connected;
                    response.Connected = new() { ClientId = "", Success = false };
                    if (clientId == null && _connectionService.AddBidirectionalConnectionStream(notification.Connect.ClientId, (StreamReader) requestStream, (StreamWriter) responseStream)) {
                        clientId = notification.Connect.ClientId;
                        response.Connected.ClientId = clientId;
                        response.Connected.Success = true;
                    }
                    await responseStream.WriteAsync(response);
                    break;
                
                case ServerNotificationType.Abort:
                    response.Type = ClientNotificationType.Aborted;
                    response.Aborted = new() { ClientId = clientId ?? "", Success = false };
                    if (clientId == notification.Abort.ClientId && _connectionService.RemoveConnection(notification.Abort.ClientId)) {
                        response.Aborted.ClientId = clientId;
                        response.Aborted.Success = true;
                        clientId = null;
                    }
                    await responseStream.WriteAsync(response);
                    break;
                
                case ServerNotificationType.OperationState:
                    if (clientId != null) {
                        _operationalService.UpdateExecutionState(notification.OperationState.HandleId,
                            (ExecutionState) notification.OperationState.ExecutionState);
                    }
                    break;
                
                case ServerNotificationType.OperationResult:
                    if (clientId != null) {
                        OperationResult result = new() {
                            RequestId = notification.OperationResult.Result.RequestId,
                            Success = notification.OperationResult.Result.Success,
                            Message = notification.OperationResult.Result.Message,
                            ExecutionState = (ExecutionState)notification.OperationResult.Result.ExecutionState,
                            OutputArguments = notification.OperationResult.Result.OutputArguments.Select(x => _mapper.Map<OperationVariable>(x)).ToList(),
                            InoutputArguments = notification.OperationResult.Result.InoutputArguments.Select(x => _mapper.Map<OperationVariable>(x)).ToList(),
                        };
                        _operationalService.SetResult(notification.OperationResult.Result.RequestId, result);
                    }
                    break;
            }

            if (clientId != null) {
                _connectionService.RemoveConnection(clientId);
                _logger.LogWarning("The client with id '" + clientId + "' disconnected without connection abort!");
            }

        }
    }
}