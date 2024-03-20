using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Sensors {

public enum EJointType 
{
    UNDEFINED = 0,
    ROTATIONAL_JOINT = 1
}

public abstract class JointSensorSource : SensorSource
{
    public abstract EJointType JointType { get; }
}


} // END namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Sensors