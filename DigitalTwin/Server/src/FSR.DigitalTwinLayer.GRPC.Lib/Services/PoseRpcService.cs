using Grpc.Core;
using FSR.DigitalTwin.App.Interfaces;
using FSR.DigitalTwin.Domain;
using FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection;

namespace FSR.DigitalTwinLayer.GRPC.Lib.Services
{
    public class PoseRpcService : PoseService.PoseServiceBase
    {        
        public override Task<PoseResponse> SendPoseData(PoseData request, ServerCallContext context)
        {
            Console.WriteLine("Received Pose Data");
            // Process the received pose data
            foreach (var landmark in request.Landmarks)
            {
                // Handle each landmark
                Console.WriteLine($"Landmark: {landmark.X}, {landmark.Y}, {landmark.Z}");
            }

            foreach (var worldLandmark in request.WorldLandmarks)
            {
                // Handle each world landmark
                Console.WriteLine($"World Landmark: {worldLandmark.X}, {worldLandmark.Y}, {worldLandmark.Z}");
            }

            // Return a response indicating success
            return Task.FromResult(new PoseResponse { Message = "Pose data received successfully" });
        }
    }
}
