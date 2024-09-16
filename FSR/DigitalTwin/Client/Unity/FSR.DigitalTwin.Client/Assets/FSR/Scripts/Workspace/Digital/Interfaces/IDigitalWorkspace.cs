using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces {

    /// <summary>
    /// The digitized workspace maintained by the digital twin.
    /// 
    /// This interface shall allow access to the following aspects
    /// - the underlying semantic information
    /// - the managed digital infrastructure
    /// - connection layer services
    /// - API callbacks and signals for assets, asset components, processes/operations etc.
    /// </summary>
    public interface IDigitalWorkspace {
        IDigitalWorkspaceServerConnection Connection { get; }
        IDigitalWorkspaceOperational Operational { get; }
        IDigitalWorkspaceAssetApi AssetApi { get; }
    }

}
