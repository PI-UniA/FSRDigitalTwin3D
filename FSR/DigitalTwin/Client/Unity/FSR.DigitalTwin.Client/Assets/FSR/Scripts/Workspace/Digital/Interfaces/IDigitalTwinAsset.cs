using System.Collections.Generic;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces {

    public interface IDigitalTwinAsset {
        string Id { get; init; }
        bool HasConnection { get; }
        List<IDigitalTwinAssetComponent> Components { set; get; }
    }

}