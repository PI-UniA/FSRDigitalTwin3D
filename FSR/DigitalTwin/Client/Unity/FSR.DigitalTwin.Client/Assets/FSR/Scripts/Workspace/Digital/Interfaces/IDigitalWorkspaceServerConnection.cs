using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces {

    public interface IDigitalWorkspaceServerConnection : IDisposable {
        ReadOnlyReactiveProperty<bool> IsConnected { get; }
        Task Connect(string ip, int port, string[] connArgs = null);
        Task<bool> Disconnect();
    }

}