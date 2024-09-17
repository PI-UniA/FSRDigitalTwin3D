using System;
using System.Threading.Tasks;
using UniRx;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces {

    public interface IDigitalWorkspaceServerConnection : IDisposable {
        ReadOnlyReactiveProperty<bool> IsConnected { get; }
        Task<bool> Connect(string[] connArgs = null);
        Task<bool> Disconnect();
    }

}