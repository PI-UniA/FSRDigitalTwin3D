using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core; 
using System;
using FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection;

public class PoseStreamingClient : MonoBehaviour
{
    private Channel channel;
    private PoseStreaming.PoseStreamingClient poseClient;
    private GameObject[] poseLandmarkCubes;

    [SerializeField] private string serverAddress = "100.83.150.133";
    [SerializeField] private int serverPort = 5001;

    void Start()
    {
        channel = new Channel($"{serverAddress}:{serverPort}", ChannelCredentials.Insecure);
        poseClient = new PoseStreaming.PoseStreamingClient(channel);

        // Initialize game objects to visualize pose landmarks
        poseLandmarkCubes = new GameObject[33]; 
        for (int i = 0; i < poseLandmarkCubes.Length; i++)
        {
            poseLandmarkCubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            poseLandmarkCubes[i].transform.position = new Vector3(0, 0, 0);  // Initial position
        }

        FetchPoseLandmarks();
    }

    async void FetchPoseLandmarks()
    {
        var request = new GetPoseLandmarksRequest();
        try
        {
            Debug.Log("Sending request for pose landmarks...");
            var poseResponse = await poseClient.GetPoseLandmarksAsync(request);
            UpdatePoseLandmarks(poseResponse);
        }
        catch (RpcException e)
        {
            Debug.LogError($"RPC Error: {e.Status.Detail} - Status Code: {e.StatusCode}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Unexpected Error: {ex.Message}");
        }
    }

    void UpdatePoseLandmarks(GetPoseLandmarksResponse poseResponse)
    {
        for (int i = 0; i < poseLandmarkCubes.Length; i++)
        {
            if (i < poseResponse.PoseLandmarks.Count)
            {
                var landmark = poseResponse.PoseLandmarks[i];
                poseLandmarkCubes[i].transform.position = new Vector3(landmark.X, landmark.Y, landmark.Z);
            }
            else
            {
                // Hide or reset the cube if there's no corresponding landmark
                poseLandmarkCubes[i].transform.position = new Vector3(0, -10, 0); // Move it out of sight
            }
        }
    }

    void OnDestroy()
    {
        channel.ShutdownAsync().Wait();
    }
}
