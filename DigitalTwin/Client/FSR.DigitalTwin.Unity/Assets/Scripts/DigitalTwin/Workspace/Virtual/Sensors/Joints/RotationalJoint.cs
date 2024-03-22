using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;


namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Sensors {

// Rotational Joint which rotates around Z-axis according to DH-Parameters
public class RotationalJoint : JointSensorSource
{
    public override EJointType JointType => EJointType.ROTATIONAL_JOINT;
    public ReadOnlyReactiveProperty<float> Z => z;

    private ReadOnlyReactiveProperty<float> z;
    
    private void Awake() {
        sensorData = gameObject.UpdateAsObservable()
            .DistinctUntilChanged()
            .Select(_ => new Hashtable { 
                {"Z", transform.localEulerAngles.z}
            });
        z = new ReadOnlyReactiveProperty<float>(sensorData.Select(x => (float) x["Z"]), transform.localEulerAngles.z);
    }
}

} // END namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Sensors