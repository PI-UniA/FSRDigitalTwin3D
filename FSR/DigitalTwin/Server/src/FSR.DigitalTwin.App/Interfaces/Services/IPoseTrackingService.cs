using FSR.DigitalTwin.Domain;

namespace FSR.DigitalTwin.App.Interfaces.Services
{
    // public interface IPoseTrackingService
    // {
    //     Task HandlePoseDataAsync(List<PoseLandmark> poseLandmarks, List<WorldPoseLandmark> worldPoseLandmarks);
    //     Task<Human> GetCurrentPoseAsync();
    //     Task FetchPoseDataAsync();
    // }

    public interface IPoseTrackingService
    {
        Human GetCurrentPose();
        void UpdateCurrentPose(Human pose);
    }
    
}