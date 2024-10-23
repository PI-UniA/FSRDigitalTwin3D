// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/DTO/Pose.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace FSR.DigitalTwin.App.GRPC.Services.Pose {
  /// <summary>
  /// Define the gRPC service
  /// </summary>
  public static partial class PoseService
  {
    static readonly string __ServiceName = "FSR.DigitalTwin.App.GRPC.PoseService";

    static readonly grpc::Marshaller<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData> __Marshaller_FSR_DigitalTwin_App_GRPC_PoseData = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseResponse> __Marshaller_FSR_DigitalTwin_App_GRPC_PoseResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData, global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseResponse> __Method_SendPoseData = new grpc::Method<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData, global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendPoseData",
        __Marshaller_FSR_DigitalTwin_App_GRPC_PoseData,
        __Marshaller_FSR_DigitalTwin_App_GRPC_PoseResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of PoseService</summary>
    [grpc::BindServiceMethod(typeof(PoseService), "BindService")]
    public abstract partial class PoseServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseResponse> SendPoseData(global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for PoseService</summary>
    public partial class PoseServiceClient : grpc::ClientBase<PoseServiceClient>
    {
      /// <summary>Creates a new client for PoseService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public PoseServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for PoseService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public PoseServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected PoseServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected PoseServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseResponse SendPoseData(global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendPoseData(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseResponse SendPoseData(global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SendPoseData, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseResponse> SendPoseDataAsync(global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SendPoseDataAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseResponse> SendPoseDataAsync(global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SendPoseData, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override PoseServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new PoseServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(PoseServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SendPoseData, serviceImpl.SendPoseData).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, PoseServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SendPoseData, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseData, global::FSR.DigitalTwin.App.GRPC.Services.Pose.PoseResponse>(serviceImpl.SendPoseData));
    }

  }
}
#endregion
