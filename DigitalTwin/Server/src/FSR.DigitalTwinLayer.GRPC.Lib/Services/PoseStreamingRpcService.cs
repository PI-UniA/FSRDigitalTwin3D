using FSR.DigitalTwin.App.Interfaces;
using FSR.DigitalTwin.Domain;
using FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection;
using Grpc.Core;

namespace FSR.DigitalTwin.App.Services
{
    public class PoseStreamingRpcService : PoseStreaming.PoseStreamingBase
    {
        private readonly IPoseTrackingService _poseTrackingService;

        public PoseStreamingRpcService(IPoseTrackingService poseTrackingService)
        {
            _poseTrackingService = poseTrackingService;
        }

        public override async Task<GetPoseLandmarksResponse> GetPoseLandmarks(GetPoseLandmarksRequest request, ServerCallContext context)
        {
            var currentPose = await _poseTrackingService.GetCurrentPoseAsync();

            var response = new GetPoseLandmarksResponse();
            foreach (var landmark in currentPose.PoseLandmarks)
            {
                var poseLandmark = new DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseLandmark
                {
                    X = landmark.X,
                    Y = landmark.Y,
                    Z = landmark.Z,
                    Visibility = (float)landmark.Visibility
                };
                response.PoseLandmarks.Add(poseLandmark);
            }

            return response;
        }

        public override async Task<GetWorldPoseLandmarksResponse> GetWorldPoseLandmarks(GetWorldPoseLandmarksRequest request, ServerCallContext context)
        {
            var currentPose = await _poseTrackingService.GetCurrentPoseAsync();

            var response = new GetWorldPoseLandmarksResponse();
            foreach (var worldLandmark in currentPose.WorldPoseLandmarks)
            {
                var worldPoseLandmark = new DigitalTwinLayer.GRPC.Lib.Services.Connection.WorldPoseLandmark
                {
                    X = worldLandmark.X,
                    Y = worldLandmark.Y,
                    Z = worldLandmark.Z,
                    Visibility = (float)worldLandmark.Visibility
                };
                response.WorldPoseLandmarks.Add(worldPoseLandmark);
            }

            return response;
        }
    }
}
