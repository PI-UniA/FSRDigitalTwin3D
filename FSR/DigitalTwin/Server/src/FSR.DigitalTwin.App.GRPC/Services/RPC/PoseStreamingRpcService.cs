// using FSR.DigitalTwin.App.GRPC.Services.Pose;
// using FSR.DigitalTwin.App.Interfaces.Services;
// using FSR.DigitalTwin.Domain;
// using FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection;
// using Grpc.Core;

// namespace FSR.DigitalTwin.App.Services
// {
//     public class PoseStreamingRpcService : PoseStreaming.PoseStreamingBase
//     {
//         // Inject the pose tracking service to access the current pose data
//         private readonly IPoseTrackingService _poseTrackingService;

//         public PoseStreamingRpcService(IPoseTrackingService poseTrackingService)
//         {
//             _poseTrackingService = poseTrackingService;
//         }

//         // Implement the streaming method
//         public override async Task StreamPoseData(StreamPoseRequest request, IServerStreamWriter<PoseData> responseStream, ServerCallContext context)
//         {
//             Console.WriteLine($"Unity client {request.ClientId} connected for pose streaming.");

//             while (!context.CancellationToken.IsCancellationRequested)
//             {
//                 // Get the current pose from the tracking service
//                 var currentPose = _poseTrackingService.GetCurrentPose();

//                 // If there is no pose data, continue the loop
//                 if (currentPose == null)
//                 {
//                     await Task.Delay(100);  // Wait a bit before trying again
//                     continue;
//                 }

//                 // Create a new PoseData message from the current pose
//                 var poseData = new PoseData
//                 {
//                     Landmarks = { currentPose.PoseLandmarks.Select(pl => new Landmark { X = pl.X, Y = pl.Y, Z = pl.Z }) },
//                     WorldLandmarks = { currentPose.WorldPoseLandmarks.Select(wl => new WorldLandmark { X = wl.X, Y = wl.Y, Z = wl.Z }) }
//                 };

//                 // Stream the pose data to the Unity client
//                 await responseStream.WriteAsync(poseData);

//                 // Wait before sending the next pose data to avoid overwhelming Unity
//                 await Task.Delay(100);  // Adjust the delay as needed for smooth streaming
//             }
//         }
//     }
// }

using Grpc.Core;
using FSR.DigitalTwin.App.GRPC.Services.Pose;
using FSR.DigitalTwin.App.Interfaces.Services;

namespace FSR.DigitalTwin.App.GRPC.Services.RPC
{
    public class PoseStreamingRpcService : PoseStreamingService.PoseStreamingServiceBase
    {
        // Inject the pose tracking service to access the current pose data
        private readonly IPoseTrackingService _poseTrackingService;

        public PoseStreamingRpcService(IPoseTrackingService poseTrackingService)
        {
            _poseTrackingService = poseTrackingService;
        }

        // Implement the streaming method
        public override async Task StreamPoseData(StreamPoseRequest request, IServerStreamWriter<PoseData> responseStream, ServerCallContext context)
        {
            Console.WriteLine($"Unity client {request.ClientId} connected for pose streaming.");

            while (!context.CancellationToken.IsCancellationRequested)
            {
                var currentPose = _poseTrackingService.GetCurrentPose();

                if (currentPose == null)
                {
                    await Task.Delay(100);
                    continue;
                }

                var poseData = new PoseData
                {
                    Landmarks = { currentPose.PoseLandmarks.Select(pl => new Landmark { X = pl.X, Y = pl.Y, Z = pl.Z }) },
                    WorldLandmarks = { currentPose.WorldPoseLandmarks.Select(wl => new WorldLandmark { X = wl.X, Y = wl.Y, Z = wl.Z }) }
                };

                await responseStream.WriteAsync(poseData);

                await Task.Delay(100);
            }
        }
    }
}
