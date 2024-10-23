using FSR.DigitalTwin.App.Common.Interfaces;
using FSR.DigitalTwin.App.Interfaces;
using FSR.DigitalTwin.Domain;

namespace FSR.DigitalTwin.App.Interfaces.Services
{
    // public class PoseTrackingService : IPoseTrackingService
    // {
    //     private readonly INodeJsCommunicationService _nodeJsCommunicationService;
    //     private Human _currentPose = new Human();

    //     public PoseTrackingService(INodeJsCommunicationService nodeJsCommunicationService)
    //     {
    //         _nodeJsCommunicationService = nodeJsCommunicationService;
    //     }

    //     // Handle pose data received from Node.js app
    //     public async Task HandlePoseDataAsync(List<PoseLandmark> poseLandmarks, List<WorldPoseLandmark> worldPoseLandmarks)
    //     {
    //         _currentPose.PoseLandmarks = poseLandmarks;
    //         _currentPose.WorldPoseLandmarks = worldPoseLandmarks;
    //         _currentPose.Timestamp = DateTime.UtcNow;

    //         await LogPoseDataAsync(poseLandmarks, worldPoseLandmarks);
    //     }

    //     // Log pose data to console
    //     private async Task LogPoseDataAsync(List<PoseLandmark> poseLandmarks, List<WorldPoseLandmark> worldPoseLandmarks)
    //     {
    //         await Console.Out.WriteLineAsync("Pose Landmarks:");
    //         foreach (var landmark in poseLandmarks)
    //         {
    //             await Console.Out.WriteLineAsync($"Normalized (x: {landmark.X}, y: {landmark.Y}, z: {landmark.Z}, visibility: {landmark.Visibility})");
    //         }

    //         await Console.Out.WriteLineAsync("World Pose Landmarks:");
    //         foreach (var worldLandmark in worldPoseLandmarks)
    //         {
    //             await Console.Out.WriteLineAsync($"World (x: {worldLandmark.X}, y: {worldLandmark.Y}, z: {worldLandmark.Z}, visibility: {worldLandmark.Visibility})");
    //         }

    //         await Console.Out.WriteLineAsync($"Timestamp: {_currentPose.Timestamp}");
    //     }

    //     // Get current pose data
    //     public async Task<Human> GetCurrentPoseAsync()
    //     {
    //         return await Task.FromResult(_currentPose);
    //     }
        
    //     // Fetch pose data from Node.js app
    //     public async Task FetchPoseDataAsync()
    //     {
    //         var (poseLandmarks, worldPoseLandmarks) = await _nodeJsCommunicationService.GetPoseDataAsync();
    //         await HandlePoseDataAsync(poseLandmarks, worldPoseLandmarks);
    //     }
    // }

    public class PoseTrackingService : IPoseTrackingService
    {
        // Store the current pose data
        private Human _currentPose;

        // Get the current pose
        public Human GetCurrentPose()
        {
            return _currentPose;
        }

        // Update the current pose
        public void UpdateCurrentPose(Human pose)
        {
            _currentPose = pose;
        }
    }
}
