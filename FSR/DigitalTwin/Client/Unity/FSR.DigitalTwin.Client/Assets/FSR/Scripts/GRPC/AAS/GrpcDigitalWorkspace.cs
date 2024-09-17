using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Core;
using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;
using Grpc.Core;
using UnityEngine;

namespace FSR.DigitalTwin.Client.Unity.GRPC.AAS {

    public class GrpcDigitalWorkspace : MonoBehaviour, IDigitalWorkspace
    {

        [SerializeField] private string digitalWorkspaceAddr = "127.0.0.1";
        [SerializeField] private int digitalWorkspacePort = 5001;

        public IDigitalWorkspaceServerConnection Connection { get => _connection ?? throw new RpcException(Status.DefaultCancelled, "No connection established!"); }
        public IDigitalWorkspaceOperational Operational { get => _operational ?? throw new RpcException(Status.DefaultCancelled, "No connection established!"); }
        public IDigitalWorkspaceEntityApi Entities { get => _entityApi ?? throw new RpcException(Status.DefaultCancelled, "No connection established!"); }

        private GrpcDigitalWorkspaceConnection _connection = null;
        private GrpcDigitalWorkspaceOperational _operational = null;
        private GrpcDigitalWorkspaceApiBridge _entityApi = null;

        private Channel _rpcChannel;

        void Awake() {
            DigitalWorkspace.SetWorkspace(this);
        }

        public async void Connect(string[] connArgs = null) {
            _rpcChannel = new Channel(digitalWorkspaceAddr, digitalWorkspacePort, ChannelCredentials.Insecure);
            _connection ??= new GrpcDigitalWorkspaceConnection(_rpcChannel);
            _operational ??= new GrpcDigitalWorkspaceOperational(_rpcChannel);
            _entityApi ??= new GrpcDigitalWorkspaceApiBridge(_rpcChannel);
            await _connection.Connect();
        }

    }

}