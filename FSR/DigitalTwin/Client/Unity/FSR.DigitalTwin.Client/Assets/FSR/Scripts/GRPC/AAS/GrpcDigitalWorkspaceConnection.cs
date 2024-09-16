using System.Threading.Tasks;
using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;
using Grpc.Core;
using UniRx;

namespace FSR.DigitalTwin.Client.Unity.GRPC.AAS {

    public class GrpcDigitalWorkspaceConnection : IDigitalWorkspaceServerConnection
    {
        public ReadOnlyReactiveProperty<bool> IsConnected => throw new System.NotImplementedException();

        private Channel _rpcChannel = null;
        public Channel RpcChannel => _rpcChannel;

        public Task<bool> Connect(string ip, int port, string[] connArgs = null)
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