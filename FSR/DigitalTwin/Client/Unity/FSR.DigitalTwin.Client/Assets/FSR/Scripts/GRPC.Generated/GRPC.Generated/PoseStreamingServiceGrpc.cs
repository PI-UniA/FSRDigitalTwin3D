// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/Services/PoseStreamingService.proto
// </auto-generated>
// Original file comments:
// syntax = "proto3";
//
// option csharp_namespace = "FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection";
//
// package FSR.DigitalTwinLayer.GRPC.Lib;
//
// message PoseLandmark {
//     float x = 1;
//     float y = 2;
//     float z = 3;
//     float visibility = 4; // Optional visibility value
// }
//
// message GetPoseLandmarksRequest {}
// message GetPoseLandmarksResponse {
//     repeated PoseLandmark poseLandmarks = 1; // List of pose landmarks
// }
//
// message WorldPoseLandmark {
//     float x = 1;
//     float y = 2;
//     float z = 3;
//     float visibility = 4; // Optional visibility value
// }
//
// message GetWorldPoseLandmarksRequest {}
// message GetWorldPoseLandmarksResponse {
//     repeated WorldPoseLandmark worldPoseLandmarks = 1; // List of world pose landmarks
// }
//
// service PoseStreaming {
//     rpc GetPoseLandmarks(GetPoseLandmarksRequest) returns (GetPoseLandmarksResponse);
//     rpc GetWorldPoseLandmarks(GetWorldPoseLandmarksRequest) returns (GetWorldPoseLandmarksResponse);
// }
//
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace FSR.DigitalTwin.App.GRPC.Services.Pose {
  /// <summary>
  /// Define the streaming service for pose data
  /// </summary>
  public static partial class PoseStreamingService
  {
    static readonly string __ServiceName = "FSR.DigitalTwin.App.GRPC.PoseStreamingService";

    static readonly grpc::Marshaller<global::FSR.DigitalTwin.App.GRPC.Services.Pose.StreamPoseRequest> __Marshaller_FSR_DigitalTwin_App_GRPC_StreamPoseRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSR.DigitalTwin.App.GRPC.Services.Pose.StreamPoseRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData> __Marshaller_FSR_DigitalTwin_App_GRPC_PoseData = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData.Parser.ParseFrom);

    static readonly grpc::Method<global::FSR.DigitalTwin.App.GRPC.Services.Pose.StreamPoseRequest, global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData> __Method_StreamPoseData = new grpc::Method<global::FSR.DigitalTwin.App.GRPC.Services.Pose.StreamPoseRequest, global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "StreamPoseData",
        __Marshaller_FSR_DigitalTwin_App_GRPC_StreamPoseRequest,
        __Marshaller_FSR_DigitalTwin_App_GRPC_PoseData);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseStreamingServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PoseStreamingService</summary>
    [grpc::BindServiceMethod(typeof(PoseStreamingService), "BindService")]
    public abstract partial class PoseStreamingServiceBase
    {
      public virtual global::System.Threading.Tasks.Task StreamPoseData(global::FSR.DigitalTwin.App.GRPC.Services.Pose.StreamPoseRequest request, grpc::IServerStreamWriter<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for PoseStreamingService</summary>
    public partial class PoseStreamingServiceClient : grpc::ClientBase<PoseStreamingServiceClient>
    {
      /// <summary>Creates a new client for PoseStreamingService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public PoseStreamingServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for PoseStreamingService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public PoseStreamingServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected PoseStreamingServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected PoseStreamingServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData> StreamPoseData(global::FSR.DigitalTwin.App.GRPC.Services.Pose.StreamPoseRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return StreamPoseData(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData> StreamPoseData(global::FSR.DigitalTwin.App.GRPC.Services.Pose.StreamPoseRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_StreamPoseData, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override PoseStreamingServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new PoseStreamingServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(PoseStreamingServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_StreamPoseData, serviceImpl.StreamPoseData).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, PoseStreamingServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_StreamPoseData, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::FSR.DigitalTwin.App.GRPC.Services.Pose.StreamPoseRequest, global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData>(serviceImpl.StreamPoseData));
    }

  }
}
#endregion
