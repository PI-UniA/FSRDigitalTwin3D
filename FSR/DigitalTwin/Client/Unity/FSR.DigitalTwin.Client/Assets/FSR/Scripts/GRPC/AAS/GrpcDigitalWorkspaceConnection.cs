using System;
using System.Threading.Tasks;
using FSR.DigitalTwin.App.GRPC.Services.DigitalTwinClientConnectionService;
using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;
using Grpc.Core;
using UniRx;
using UnityEngine;

namespace FSR.DigitalTwin.Client.Unity.GRPC.AAS {

    public class GrpcDigitalWorkspaceConnection : IDigitalWorkspaceServerConnection
    {
        public ReadOnlyReactiveProperty<bool> IsConnected => _isConnected.ToReadOnlyReactiveProperty();
        public Channel RpcChannel => _rpcChannel ?? throw new RpcException(Status.DefaultCancelled, "No connection established!");

        private Channel _rpcChannel = null;
        private DigitalTwinClientConnectionService.DigitalTwinClientConnectionServiceClient _client = null;
        private AsyncDuplexStreamingCall<ServerNotification, ClientNotification> _notificationStream = null;

        private string _addr;
        private int _port;
        private ReactiveProperty<bool> _isConnected;

        public GrpcDigitalWorkspaceConnection(string addr, int port) {
            _addr = addr;
            _port = port;
            _isConnected = new(false);
        }

        public async Task<bool> Connect(string[] connArgs = null)
        {
            _rpcChannel = new Channel(_addr, _port, ChannelCredentials.Insecure);
            _client = new(_rpcChannel);
            // var testMessage = await _client.GetTestMessageAsync(new TestMessage() { Info = "Foo" });
            // Debug.Log(testMessage.Info);

            _notificationStream = _client.Connect();

            ServerNotification connectNotification = new() {
                Type = ServerNotificationType.Connect,
                Connect = new ConnectServerNotification() {
                    ClientId = "FSR.DigitalTwin.Client.Unity::0"
                }
            };
            await _notificationStream.RequestStream.WriteAsync(connectNotification);
            await _notificationStream.ResponseStream.MoveNext();
            var result = _notificationStream.ResponseStream.Current;

            if (result.Connected.Success) {
                _isConnected.Value = true;
                Debug.Log("Connection established!");
            }
            else {
                Debug.LogError("Failed to connect to digital twin workspace!");
            }

            while (await _notificationStream.ResponseStream.MoveNext()) {
                if (_notificationStream.ResponseStream.Current.Type == ClientNotificationType.Aborted)
                    break;
                Debug.Log("Client Notification> " + _notificationStream.ResponseStream.Current.Type);
            }
            _isConnected.Value = false;
            _notificationStream = null;
            return true;
        }

        public async Task<bool> Disconnect()
        {
            await _notificationStream.RequestStream.WriteAsync(new ServerNotification() {
                Type = ServerNotificationType.Abort,
                Abort = new AbortServerNotification() { ClientId = "FSR.DigitalTwin.Client.Unity::0" }
            });
            return true;
        }

        public async void Dispose() => await Disconnect();
    }

}