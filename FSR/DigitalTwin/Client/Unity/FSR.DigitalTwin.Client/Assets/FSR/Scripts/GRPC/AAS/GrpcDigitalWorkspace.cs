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
        public IDigitalWorkspaceAssetApi AssetApi { get => _assetApi ?? throw new RpcException(Status.DefaultCancelled, "No connection established!"); }
    
        private GrpcDigitalWorkspaceConnection _connection = null;
        private GrpcDigitalWorkspaceOperational _operational = null;
        private GrpcDigitalWorkspaceApiBridge _assetApi = null;

        private Channel _rpcChannel;

        void Awake() {
            DigitalWorkspace.SetWorkspace(this);
        }

        public async void Connect() {
            _connection ??= new GrpcDigitalWorkspaceConnection();
            if (await _connection.Connect(digitalWorkspaceAddr, digitalWorkspacePort)) {
                _rpcChannel = _connection.RpcChannel;
                _operational ??= new GrpcDigitalWorkspaceOperational(_rpcChannel);
                _assetApi ??= new GrpcDigitalWorkspaceApiBridge(_rpcChannel);
            }
        }

    }

}