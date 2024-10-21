using FSR.DigitalTwin.Domain;

namespace FSR.DigitalTwin.App.Interfaces
{
    public interface IPoseTrackingService
    {
        Task HandlePoseDataAsync(List<PoseLandmark> poseLandmarks, List<WorldPoseLandmark> worldPoseLandmarks);
        Task<Human> GetCurrentPoseAsync();
        Task FetchPoseDataAsync();
    }
}
