using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Core;
using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;
using Grpc.Core;
using UniRx;
using UnityEngine;

namespace FSR.DigitalTwin.Client.Unity.GRPC.AAS {

    public class GrpcDigitalWorkspace : MonoBehaviour, IDigitalWorkspace
    {
        [SerializeField] private string digitalWorkspaceAddr = "127.0.0.1";
        [SerializeField] private int digitalWorkspacePort = 5001;

        public IDigitalWorkspaceServerConnection Connection { get => _connection ?? throw new System.Exception("Should not happen!"); }
        public IDigitalWorkspaceOperational Operational { get => _operational ?? throw new RpcException(Status.DefaultCancelled, "No connection established!"); }
        public IDigitalWorkspaceEntityApi Entities { get => _entityApi ?? throw new RpcException(Status.DefaultCancelled, "No connection established!"); }

        private GrpcDigitalWorkspaceConnection _connection = null;
        private GrpcDigitalWorkspaceOperational _operational = null;
        private GrpcDigitalWorkspaceApiBridge _entityApi = null;

        void Awake() {
            DigitalWorkspace.SetWorkspace(this);
            _connection = new GrpcDigitalWorkspaceConnection(digitalWorkspaceAddr, digitalWorkspacePort);
            _connection.IsConnected.Where(x => x).Subscribe(_ => OnConnect()).AddTo(this);
        }

        public void OnConnect() {
            _operational ??= new GrpcDigitalWorkspaceOperational(_connection.RpcChannel);
            _entityApi ??= new GrpcDigitalWorkspaceApiBridge(_connection.RpcChannel);
        }

    }

}