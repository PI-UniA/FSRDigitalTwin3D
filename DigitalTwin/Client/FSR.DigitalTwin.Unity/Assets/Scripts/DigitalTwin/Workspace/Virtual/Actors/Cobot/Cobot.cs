using System.Collections;
using System.Collections.Generic;
using FSR.DigitalTwin.Unity.Workspace.Virtual.Actors;
using FSR.DigitalTwin.Unity.Workspace.Virtual.Sensors;
using UnityEngine;

namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Actors {

// A cobot is a simple kinematic (robot arm) consisting of (for now) rotational joints.
// 
// Using a set of joints, the kinematic can be controlled and transformed internally and externally
public class Cobot : BaseActor
{

    [SerializeField] private List<JointSensorSource> joints;
    


}

} // END namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Actors 
