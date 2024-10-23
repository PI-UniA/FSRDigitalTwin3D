using System;
using System.Threading.Tasks;
using Grpc.Core;
using UnityEngine;
using FSR.DigitalTwin.App.GRPC.Services.Pose;

public class PoseStreamingClient : MonoBehaviour
{
    private PoseStreamingService.PoseStreamingServiceClient streamingClient;
    private Channel channel;

    void Start()
    {
        InitializeGrpc();
        StreamPoseData();
    }

    private void InitializeGrpc()
    {
        // Create a channel to connect to the gRPC server
        channel = new Channel("localhost:5001", ChannelCredentials.Insecure);
        streamingClient = new PoseStreamingService.PoseStreamingServiceClient(channel);
    }

    private async void StreamPoseData()
    {
        // Create a request to initiate streaming
        var request = new StreamPoseRequest { ClientId = "UnityClient" };

        using (var call = streamingClient.StreamPoseData(request))
        {
            try
            {
                while (await call.ResponseStream.MoveNext())
                {
                    PoseData poseData = call.ResponseStream.Current;
                    ProcessPoseData(poseData);
                }
            }
            catch (RpcException e)
            {
                Debug.LogError($"Error during gRPC streaming: {e.Status}");
            }
        }
    }

    private void ProcessPoseData(PoseData poseData)
    {
        // Process the received pose data
        foreach (var landmark in poseData.Landmarks)
        {
            Debug.Log($"Landmark: X={landmark.X}, Y={landmark.Y}, Z={landmark.Z}");
        }

        foreach (var worldLandmark in poseData.WorldLandmarks)
        {
            Debug.Log($"World Landmark: X={worldLandmark.X}, Y={worldLandmark.Y}, Z={worldLandmark.Z}");
        }

        // TODO: update Unity scene with the new pose data
    }

    private void OnApplicationQuit()
    {
        channel.ShutdownAsync().Wait();
    }
}
