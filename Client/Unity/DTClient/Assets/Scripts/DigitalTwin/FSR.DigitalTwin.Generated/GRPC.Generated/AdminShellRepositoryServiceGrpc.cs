// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/Services/AdminShellRepositoryService.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository {
  public static partial class AssetAdministrationShellRepositoryService
  {
    static readonly string __ServiceName = "FSRAas.GRPC.Lib.V3.AssetAdministrationShellRepositoryService";

    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcRequest> __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsRpcRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcResponse> __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsRpcResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcRequest> __Marshaller_FSRAas_GRPC_Lib_V3_GetAssetAdministrationShellByIdRpcRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcResponse> __Marshaller_FSRAas_GRPC_Lib_V3_GetAssetAdministrationShellByIdRpcResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcRequest> __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsByAssetIdRpcRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcResponse> __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsByAssetIdRpcResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcRequest> __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsByIdShortRpcRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcResponse> __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsByIdShortRpcResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcRequest> __Marshaller_FSRAas_GRPC_Lib_V3_PostAssetAdministrationShellRpcRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcResponse> __Marshaller_FSRAas_GRPC_Lib_V3_PostAssetAdministrationShellRpcResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcRequest> __Marshaller_FSRAas_GRPC_Lib_V3_PutAssetAdministrationShellByIdRpcRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcResponse> __Marshaller_FSRAas_GRPC_Lib_V3_PutAssetAdministrationShellByIdRpcResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcResponse.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcRequest> __Marshaller_FSRAas_GRPC_Lib_V3_DeleteAssetAdministrationShellByIdRpcRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcResponse> __Marshaller_FSRAas_GRPC_Lib_V3_DeleteAssetAdministrationShellByIdRpcResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcResponse> __Method_GetAllAssetAdministrationShells = new grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllAssetAdministrationShells",
        __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsRpcRequest,
        __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsRpcResponse);

    static readonly grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcResponse> __Method_GetAssetAdministrationShellById = new grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAssetAdministrationShellById",
        __Marshaller_FSRAas_GRPC_Lib_V3_GetAssetAdministrationShellByIdRpcRequest,
        __Marshaller_FSRAas_GRPC_Lib_V3_GetAssetAdministrationShellByIdRpcResponse);

    static readonly grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcResponse> __Method_GetAllAssetAdministrationShellsByAssetId = new grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllAssetAdministrationShellsByAssetId",
        __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsByAssetIdRpcRequest,
        __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsByAssetIdRpcResponse);

    static readonly grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcResponse> __Method_GetAllAssetAdministrationShellsByIdShort = new grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAllAssetAdministrationShellsByIdShort",
        __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsByIdShortRpcRequest,
        __Marshaller_FSRAas_GRPC_Lib_V3_GetAllAssetAdministrationShellsByIdShortRpcResponse);

    static readonly grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcResponse> __Method_PostAssetAdministrationShell = new grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "PostAssetAdministrationShell",
        __Marshaller_FSRAas_GRPC_Lib_V3_PostAssetAdministrationShellRpcRequest,
        __Marshaller_FSRAas_GRPC_Lib_V3_PostAssetAdministrationShellRpcResponse);

    static readonly grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcResponse> __Method_PutAssetAdministrationShellById = new grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "PutAssetAdministrationShellById",
        __Marshaller_FSRAas_GRPC_Lib_V3_PutAssetAdministrationShellByIdRpcRequest,
        __Marshaller_FSRAas_GRPC_Lib_V3_PutAssetAdministrationShellByIdRpcResponse);

    static readonly grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcResponse> __Method_DeleteAssetAdministrationShellById = new grpc::Method<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteAssetAdministrationShellById",
        __Marshaller_FSRAas_GRPC_Lib_V3_DeleteAssetAdministrationShellByIdRpcRequest,
        __Marshaller_FSRAas_GRPC_Lib_V3_DeleteAssetAdministrationShellByIdRpcResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.AdminShellRepositoryServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of AssetAdministrationShellRepositoryService</summary>
    [grpc::BindServiceMethod(typeof(AssetAdministrationShellRepositoryService), "BindService")]
    public abstract partial class AssetAdministrationShellRepositoryServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcResponse> GetAllAssetAdministrationShells(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcResponse> GetAssetAdministrationShellById(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcResponse> GetAllAssetAdministrationShellsByAssetId(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcResponse> GetAllAssetAdministrationShellsByIdShort(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcResponse> PostAssetAdministrationShell(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcResponse> PutAssetAdministrationShellById(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      public virtual global::System.Threading.Tasks.Task<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcResponse> DeleteAssetAdministrationShellById(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for AssetAdministrationShellRepositoryService</summary>
    public partial class AssetAdministrationShellRepositoryServiceClient : grpc::ClientBase<AssetAdministrationShellRepositoryServiceClient>
    {
      /// <summary>Creates a new client for AssetAdministrationShellRepositoryService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public AssetAdministrationShellRepositoryServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for AssetAdministrationShellRepositoryService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public AssetAdministrationShellRepositoryServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected AssetAdministrationShellRepositoryServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected AssetAdministrationShellRepositoryServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcResponse GetAllAssetAdministrationShells(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllAssetAdministrationShells(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcResponse GetAllAssetAdministrationShells(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllAssetAdministrationShells, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcResponse> GetAllAssetAdministrationShellsAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllAssetAdministrationShellsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcResponse> GetAllAssetAdministrationShellsAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllAssetAdministrationShells, null, options, request);
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcResponse GetAssetAdministrationShellById(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAssetAdministrationShellById(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcResponse GetAssetAdministrationShellById(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAssetAdministrationShellById, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcResponse> GetAssetAdministrationShellByIdAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAssetAdministrationShellByIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcResponse> GetAssetAdministrationShellByIdAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAssetAdministrationShellById, null, options, request);
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcResponse GetAllAssetAdministrationShellsByAssetId(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllAssetAdministrationShellsByAssetId(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcResponse GetAllAssetAdministrationShellsByAssetId(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllAssetAdministrationShellsByAssetId, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcResponse> GetAllAssetAdministrationShellsByAssetIdAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllAssetAdministrationShellsByAssetIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcResponse> GetAllAssetAdministrationShellsByAssetIdAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllAssetAdministrationShellsByAssetId, null, options, request);
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcResponse GetAllAssetAdministrationShellsByIdShort(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllAssetAdministrationShellsByIdShort(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcResponse GetAllAssetAdministrationShellsByIdShort(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAllAssetAdministrationShellsByIdShort, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcResponse> GetAllAssetAdministrationShellsByIdShortAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllAssetAdministrationShellsByIdShortAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcResponse> GetAllAssetAdministrationShellsByIdShortAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAllAssetAdministrationShellsByIdShort, null, options, request);
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcResponse PostAssetAdministrationShell(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PostAssetAdministrationShell(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcResponse PostAssetAdministrationShell(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_PostAssetAdministrationShell, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcResponse> PostAssetAdministrationShellAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PostAssetAdministrationShellAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcResponse> PostAssetAdministrationShellAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_PostAssetAdministrationShell, null, options, request);
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcResponse PutAssetAdministrationShellById(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PutAssetAdministrationShellById(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcResponse PutAssetAdministrationShellById(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_PutAssetAdministrationShellById, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcResponse> PutAssetAdministrationShellByIdAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return PutAssetAdministrationShellByIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcResponse> PutAssetAdministrationShellByIdAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_PutAssetAdministrationShellById, null, options, request);
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcResponse DeleteAssetAdministrationShellById(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteAssetAdministrationShellById(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcResponse DeleteAssetAdministrationShellById(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteAssetAdministrationShellById, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcResponse> DeleteAssetAdministrationShellByIdAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteAssetAdministrationShellByIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcResponse> DeleteAssetAdministrationShellByIdAsync(global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteAssetAdministrationShellById, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override AssetAdministrationShellRepositoryServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new AssetAdministrationShellRepositoryServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(AssetAdministrationShellRepositoryServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAllAssetAdministrationShells, serviceImpl.GetAllAssetAdministrationShells)
          .AddMethod(__Method_GetAssetAdministrationShellById, serviceImpl.GetAssetAdministrationShellById)
          .AddMethod(__Method_GetAllAssetAdministrationShellsByAssetId, serviceImpl.GetAllAssetAdministrationShellsByAssetId)
          .AddMethod(__Method_GetAllAssetAdministrationShellsByIdShort, serviceImpl.GetAllAssetAdministrationShellsByIdShort)
          .AddMethod(__Method_PostAssetAdministrationShell, serviceImpl.PostAssetAdministrationShell)
          .AddMethod(__Method_PutAssetAdministrationShellById, serviceImpl.PutAssetAdministrationShellById)
          .AddMethod(__Method_DeleteAssetAdministrationShellById, serviceImpl.DeleteAssetAdministrationShellById).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, AssetAdministrationShellRepositoryServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAllAssetAdministrationShells, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsRpcResponse>(serviceImpl.GetAllAssetAdministrationShells));
      serviceBinder.AddMethod(__Method_GetAssetAdministrationShellById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAssetAdministrationShellByIdRpcResponse>(serviceImpl.GetAssetAdministrationShellById));
      serviceBinder.AddMethod(__Method_GetAllAssetAdministrationShellsByAssetId, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByAssetIdRpcResponse>(serviceImpl.GetAllAssetAdministrationShellsByAssetId));
      serviceBinder.AddMethod(__Method_GetAllAssetAdministrationShellsByIdShort, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.GetAllAssetAdministrationShellsByIdShortRpcResponse>(serviceImpl.GetAllAssetAdministrationShellsByIdShort));
      serviceBinder.AddMethod(__Method_PostAssetAdministrationShell, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PostAssetAdministrationShellRpcResponse>(serviceImpl.PostAssetAdministrationShell));
      serviceBinder.AddMethod(__Method_PutAssetAdministrationShellById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.PutAssetAdministrationShellByIdRpcResponse>(serviceImpl.PutAssetAdministrationShellById));
      serviceBinder.AddMethod(__Method_DeleteAssetAdministrationShellById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcRequest, global::FSRAas.GRPC.Lib.V3.Services.AssetAdministrationShellRepository.DeleteAssetAdministrationShellByIdRpcResponse>(serviceImpl.DeleteAssetAdministrationShellById));
    }

  }
}
#endregion
