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

            var ur5e = "https://www.hs-emden-leer.de/ids/aas/2414_0152_5032_4364";
            var ur5eOperationals = "https://www.hs-emden-leer.de/ids/sm/6494_2162_5032_2813";
            var ur5eNameplate = "https://www.hs-emden-leer.de/ids/sm/1225_9020_5022_1974";
            Debug.Log("0>>> " + _entityApi.HasComponentProperty(ur5eNameplate, "ContactInformation.RoleOfContactPerson"));
            Debug.Log("1>>> " + _entityApi.HasComponentProperty(ur5eNameplate, "ContactInformation"));
            // Debug.Log("2>>> " + _entityApi.CreateComponentProperty(ur5eOperationals, "Foobar", "Hello World!"));
            // Debug.Log("3>>> " + _entityApi.CreateComponentProperty(ur5eOperationals, "Foobar", "Hello World!"));
            // Debug.Log("4>>> " + _entityApi.HasComponentProperty(ur5eOperationals, "Foobar"));
        }

        async void OnDestroy() {
            if (_connection.IsConnected.Value) {
                await _connection.Disconnect();
            }
        }

    }

}