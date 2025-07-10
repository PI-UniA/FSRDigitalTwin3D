using UnityEngine;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Virtual.Interfaces.Robot     {

    public interface IRosSourceDestinationPublisher {

        string TopicName { get; }
        GameObject Robot { get; }
        GameObject Target { get; }
        GameObject TargetPlacement { get; }

        public void Publish();

    }

}