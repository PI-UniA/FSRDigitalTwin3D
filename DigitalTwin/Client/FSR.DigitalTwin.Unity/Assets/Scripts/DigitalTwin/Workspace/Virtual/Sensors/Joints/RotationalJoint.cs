using System.Collections;
using UniRx;
using UniRx.Triggers;


namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Sensors {

// Rotational Joint which rotates around Z-axis according to DH-Parameters
public class RotationalJoint : JointSensorSource
{
    public override EJointType JointType => EJointType.ROTATIONAL_JOINT;

    private void Awake() {
        sensorData = gameObject.UpdateAsObservable()
            .Select(_ => new Hashtable { 
                {"Z", transform.localRotation.z}
            })
            .DistinctUntilChanged();
    }
}

} // END namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Sensors