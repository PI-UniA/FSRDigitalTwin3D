using System.Collections.Generic;
using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;
using UnityEngine;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Virtual.Asset {
    public abstract class DigitalTwinActorBase : MonoBehaviour, IDigitalTwinEntity
    {
        public string Id { get => throw new System.NotImplementedException(); init => throw new System.NotImplementedException(); }

        public bool HasConnection => throw new System.NotImplementedException();

        public List<IDigitalTwinEntityComponent> Components { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}

