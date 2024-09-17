using System.Threading.Tasks;
using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;
using Grpc.Core;
using UniRx;

namespace FSR.DigitalTwin.Client.Unity.GRPC.AAS {

    public class GrpcDigitalWorkspaceConnection : IDigitalWorkspaceServerConnection
    {
        public ReadOnlyReactiveProperty<bool> IsConnected => throw new System.NotImplementedException();
        public Channel RpcChannel { get; init; }

        public GrpcDigitalWorkspaceConnection(Channel rpcChannel) {
            RpcChannel = rpcChannel;
        }

        public Task<bool> Connect(string[] connArgs = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Disconnect()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }

}