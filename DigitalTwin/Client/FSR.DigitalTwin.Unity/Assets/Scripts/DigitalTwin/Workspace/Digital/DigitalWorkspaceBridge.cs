using System;
using System.Linq;
using System.Threading.Tasks;
using FSR.Aas.GRPC.Lib.V3;
using FSR.Aas.GRPC.Lib.V3.Services;
using FSR.Aas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository;
using FSR.Aas.GRPC.Lib.V3.Services.SubmodelRepository;
using FSR.Aas.GRPC.Lib.V3.Services.SubmodelService;
using FSR.Aas.GRPC.Lib.V3.Services.Operational;
using FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection;
using FSR.DigitalTwin.Unity.Workspace.Digital.Services;
using Grpc.Core;
using UnityEngine;
using Unity.VisualScripting;
using System.IO;
using UnityEngine.UIElements;
using System.Threading;
using Operational = FSR.Aas.GRPC.Lib.V3.Services.Operational.DigitalTwinLayerOperationalService.DigitalTwinLayerOperationalServiceClient;
using Connection = FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.DigitalTwinLayerConnectionService.DigitalTwinLayerConnectionServiceClient;

namespace FSR.DigitalTwin.Unity.Workspace.Digital {

public class DigitalWorkspaceBridge : MonoBehaviour
{
    [SerializeField] private string digitalWorkspaceAddr = "127.0.0.1";
    [SerializeField] private int digitalWorkspacePort = 5001;

    public Channel RpcChannel { get; }
    public AdminShellApiServiceClient AasApiClient { get; }
    public Operational Operational { get; }
    public Connection Connection { get; }

    public DigitalWorkspaceBridge() {
        RpcChannel = new Channel(digitalWorkspaceAddr, digitalWorkspacePort, ChannelCredentials.Insecure);
        AasApiClient = new AdminShellApiServiceClient(RpcChannel);
        Operational = new(RpcChannel);
        Connection = new(RpcChannel);
    }

    async void Start() {
        Debug.Log("Running data channel test...");
        await DigitalWorkspaceExampleRequests.RunSyncInvokeRequest(AasApiClient, Connection, Operational, RpcChannel);
        Debug.Log("Done!");
    }

}


// ============================================================= //
// Test Requests to AAS
// ============================================================= //
public class DigitalWorkspaceExampleRequests {
    public static async Task RunSyncInvokeRequest(AdminShellApiServiceClient client, Connection connection, Operational operational, Channel channel) {
        // Thread simulatedExternalRequest = new(() => {
        //     InvokeOperationSyncRequest invokeRequest = new() {
        //         SubmodelId = "aHR0cHM6Ly93d3cuaHMtZW1kZW4tbGVlci5kZS9pZHMvc20vNjQ5NF8yMTYyXzUwMzJfMjgxMw",
        //         Timestamp = 0,
        //         RequestId = "MyRequestId::1",
        //     };
        //     SubmodelElementDTO inputVar = new() {
        //         IdShort = "TestVar",
        //         SubmodelElementType = SubmodelElementType.Property,
        //         Property = new PropertyPayloadDTO() {
        //             ValueType = DataTypeDefXsd.Integer,
        //             Value = "42"
        //         }
        //     };
        //     invokeRequest.InputArguments.Add(new OperationVariableDTO() { Value = inputVar });
        //     invokeRequest.Path.Add(new KeyDTO() { Type = KeyTypes.Operation, Value = "pick_and_place" });
        //     var invokeResponse = client.Submodel.InvokeOperationSync(invokeRequest);
        //     Debug.Log("[From server]: Success = " + invokeResponse.Payload.Success + ", Message = " + invokeResponse.Payload.Message);
        // });

        Thread simulatedExternalRequest = new(async () => {
            InvokeOperationAsyncRequest invokeRequest = new() {
                SubmodelId = "aHR0cHM6Ly93d3cuaHMtZW1kZW4tbGVlci5kZS9pZHMvc20vNjQ5NF8yMTYyXzUwMzJfMjgxMw",
                Timestamp = 0,
                RequestId = "MyRequestId::1",
            };
            invokeRequest.Path.Add(new KeyDTO() { Type = KeyTypes.Operation, Value = "pick_and_place" });
            var invokeResponse = client.Submodel.InvokeOperationAsync(invokeRequest);
            Debug.Log("[From server]: Async invoke request = " + invokeResponse.Payload);

            GetOperationAsyncResultRequest resultRequest = new() {
                HandleId = invokeResponse.Payload
            };
            var resultResponse = client.Submodel.GetOperationAsyncResult(resultRequest);
            Debug.Log("[From server]: Execution State = " + resultResponse.Result.ExecutionState);

            await Task.Delay(5000); // Wait for result

            resultResponse = client.Submodel.GetOperationAsyncResult(resultRequest);
            Debug.Log("[From server]: Execution State = " + resultResponse.Result.ExecutionState + ", Success = " + resultResponse.Result.Success);
        });

        var connectRequest = new ConnectRequest() {
            Type = DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerType.DtLayerTypeVirtual,
            Info = "Unity Visualisation Layer"
        };
        var connectResponse = await connection.ConnectAsync(connectRequest);
        if (!connectResponse.Success) {
            Debug.LogError(connectResponse.Message);
            return;
        }

        var invokeStream = operational.OpenOperationInvocationStream();
        var resultStream = operational.OpenOperationResultStream();
        // var statusStream = operational.OpenExecutionStateStream();

        simulatedExternalRequest.Start();

        while (await invokeStream.ResponseStream.MoveNext()) {
            Debug.Log("[From server]: " + invokeStream.ResponseStream.Current.RequestId);
            await invokeStream.RequestStream.WriteAsync(new OperationStatus { ExecutionState = ExecutionState.Completed, RequestId = invokeStream.ResponseStream.Current.RequestId });
            
            await resultStream.ResponseStream.MoveNext();
            Debug.Log("[From server]: " + resultStream.ResponseStream.Current.RequestId);
            Debug.Log("[From server]: Number of input parameters is " + invokeStream.ResponseStream.Current.InputVariables.Count);
            Debug.Log("[From server]: Number of in-output parameters is " + invokeStream.ResponseStream.Current.InoutVariables.Count);

            await Task.Delay(3000); // Do some work...

            await resultStream.RequestStream.WriteAsync(new OperationResult() {
                Success = true,
                RequestId = resultStream.ResponseStream.Current.RequestId,
                ExecutionState = ExecutionState.Completed,
                Message = "Test operation finished!"
            });
            
            var abortResponse = await connection.AbortConnectionAsync(new AbortConnectionRequest() { LayerId = "DTLayer::0", Type = DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerType.DtLayerTypeVirtual });
            if (!abortResponse.Success) {
                Debug.LogError(abortResponse.Message);
                return;
            }
        }

        simulatedExternalRequest.Join();
    }
}
// ============================================================= //
// END - Test Requests to AAS
// ============================================================= //


} // END namespace FSR.Workspace.Digital