using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FSR.DigitalTwin.Unity.Workspace.Digital;
using FSR.DigitalTwin.Unity.Workspace.Digital.Interfaces;
using FSR.DigitalTwin.Unity.Workspace.Virtual.Sensors;
using UnityEngine;

namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Actors {

    /// <summary>
    /// A cobot is a simple kinematic (robot arm) consisting of (for now) rotational joints.
    /// Using a set of joints, the kinematic can be controlled and transformed internally and externally
    /// </summary>
    public class Cobot : BaseActor
    {
        [SerializeField] private List<JointSensorSource> joints;

        public DigitalWorkspace DigitalWorkspace => DigitalWorkspace.Instance;

        public void SetJointRotation(int index, float z) {
            if (joints[index].JointType == EJointType.ROTATIONAL_JOINT) {
                var localEulerAngles = joints[index].transform.localEulerAngles;
                localEulerAngles.z = z;
                joints[index].transform.localEulerAngles = localEulerAngles;
            }
        }
    }

} // END namespace FSR.DigitalTwin.Unity.Workspace.Virtual.Actors 
