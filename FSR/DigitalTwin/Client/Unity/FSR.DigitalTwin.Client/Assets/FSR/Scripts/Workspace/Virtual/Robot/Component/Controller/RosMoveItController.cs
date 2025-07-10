using UnityEngine;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Virtual.Robot.Component.Controller
{
    /// <summary>
    /// A robot controller that uses the MoveIt service running in a ROS2 workspace for planning.
    /// </summary>
    public class RosMoveitController : RobotControllerComponent
    {
        public override GameObject Robot => throw new System.NotImplementedException();

        public override bool HasPlanned => throw new System.NotImplementedException();

        public override bool IsValid => throw new System.NotImplementedException();

        public override bool IsInterrupted => throw new System.NotImplementedException();

        public override bool IsRunning => throw new System.NotImplementedException();

        public override void ForceInterrupt()
        {
            throw new System.NotImplementedException();
        }

        public override bool Interrupt()
        {
            throw new System.NotImplementedException();
        }

        public override void Plan()
        {
            throw new System.NotImplementedException();
        }

        public override void RunPlan()
        {
            throw new System.NotImplementedException();
        }

        public override bool ValidatePlan()
        {
            throw new System.NotImplementedException();
        }
    }
}