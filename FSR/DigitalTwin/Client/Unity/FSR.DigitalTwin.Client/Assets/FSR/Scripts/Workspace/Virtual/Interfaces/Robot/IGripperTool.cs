namespace FSR.DigitalTwin.Client.Unity.Workspace.Virtual.Interfaces.Robot {

    public interface IGripperTool {

        bool Opened { get; }

        void OpenGripper();
        void CloseGripper();

    }

}