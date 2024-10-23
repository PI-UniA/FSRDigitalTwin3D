using Grpc.Core;
using FSR.DigitalTwin.App.Interfaces;
using FSR.DigitalTwin.Domain;
using FSR.DigitalTwin.App.GRPC.Services.Pose;
using FSR.DigitalTwin.App.Interfaces.Services;

namespace FSR.DigitalTwin.App.GRPC.Services.RPC
{
    public class PoseRpcService : PoseService.PoseServiceBase
    {
        private readonly IPoseTrackingService _poseTrackingService;
        public PoseRpcService(IPoseTrackingService poseTrackingService)
        {
            _poseTrackingService = poseTrackingService;
        }       
        // public override Task<PoseResponse> SendPoseData(PoseData request, ServerCallContext context)
        // {
        //     Console.WriteLine("Received Pose Data");
        //     // Process the received pose data
        //     foreach (var landmark in request.Landmarks)
        //     {
        //         // Handle each landmark
        //         Console.WriteLine($"Landmark: {landmark.X}, {landmark.Y}, {landmark.Z}");
        //     }

        //     foreach (var worldLandmark in request.WorldLandmarks)
        //     {
        //         // Handle each world landmark
        //         Console.WriteLine($"World Landmark: {worldLandmark.X}, {worldLandmark.Y}, {worldLandmark.Z}");
        //     }

        //     // Return a response indicating success
        //     return Task.FromResult(new PoseResponse { Message = "Pose data received successfully" });
        // }

        public override Task<PoseResponse> SendPoseData(PoseData request, ServerCallContext context)
    {
        Console.WriteLine("Received Pose Data");

        var human = new Human
        {
            PoseLandmarks = request.Landmarks.Select(l => new PoseLandmark { X = l.X, Y = l.Y, Z = l.Z }).ToList(),
            WorldPoseLandmarks = request.WorldLandmarks.Select(wl => new WorldPoseLandmark { X = wl.X, Y = wl.Y, Z = wl.Z }).ToList()
        };

        // Store the received data in the pose tracking service
        _poseTrackingService.UpdateCurrentPose(human);

        // Log the landmarks (optional)
        foreach (var landmark in request.Landmarks)
        {
            Console.WriteLine($"Landmark: {landmark.X}, {landmark.Y}, {landmark.Z}");
        }

        foreach (var worldLandmark in request.WorldLandmarks)
        {
            Console.WriteLine($"World Landmark: {worldLandmark.X}, {worldLandmark.Y}, {worldLandmark.Z}");
        }

        // Return a response indicating success
        return Task.FromResult(new PoseResponse { Message = "Pose data received and stored successfully" });
    }
    }
}
