using System.Collections.Generic;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces {

    public interface IDigitalTwinEntity {
        string Id { get; init; }
        bool HasConnection { get; }
        List<IDigitalTwinEntityComponent> Components { set; get; }
    }

}