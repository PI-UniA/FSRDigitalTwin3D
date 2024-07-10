# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
import grpc

from Protos.Services import AdminShellRepositoryService_pb2 as Protos_dot_Services_dot_AdminShellRepositoryService__pb2


class AssetAdministrationShellRepositoryServiceStub(object):
  # missing associated documentation comment in .proto file
  pass

  def __init__(self, channel):
    """Constructor.

    Args:
      channel: A grpc.Channel.
    """
    self.GetAllAssetAdministrationShells = channel.unary_unary(
        '/FSR.Aas.GRPC.Lib.V3.AssetAdministrationShellRepositoryService/GetAllAssetAdministrationShells',
        request_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsRpcRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsRpcResponse.FromString,
        )
    self.GetAssetAdministrationShellById = channel.unary_unary(
        '/FSR.Aas.GRPC.Lib.V3.AssetAdministrationShellRepositoryService/GetAssetAdministrationShellById',
        request_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAssetAdministrationShellByIdRpcRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAssetAdministrationShellByIdRpcResponse.FromString,
        )
    self.GetAllAssetAdministrationShellsByAssetId = channel.unary_unary(
        '/FSR.Aas.GRPC.Lib.V3.AssetAdministrationShellRepositoryService/GetAllAssetAdministrationShellsByAssetId',
        request_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsByAssetIdRpcRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsByAssetIdRpcResponse.FromString,
        )
    self.GetAllAssetAdministrationShellsByIdShort = channel.unary_unary(
        '/FSR.Aas.GRPC.Lib.V3.AssetAdministrationShellRepositoryService/GetAllAssetAdministrationShellsByIdShort',
        request_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsByIdShortRpcRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsByIdShortRpcResponse.FromString,
        )
    self.PostAssetAdministrationShell = channel.unary_unary(
        '/FSR.Aas.GRPC.Lib.V3.AssetAdministrationShellRepositoryService/PostAssetAdministrationShell',
        request_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.PostAssetAdministrationShellRpcRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.PostAssetAdministrationShellRpcResponse.FromString,
        )
    self.PutAssetAdministrationShellById = channel.unary_unary(
        '/FSR.Aas.GRPC.Lib.V3.AssetAdministrationShellRepositoryService/PutAssetAdministrationShellById',
        request_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.PutAssetAdministrationShellByIdRpcRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.PutAssetAdministrationShellByIdRpcResponse.FromString,
        )
    self.DeleteAssetAdministrationShellById = channel.unary_unary(
        '/FSR.Aas.GRPC.Lib.V3.AssetAdministrationShellRepositoryService/DeleteAssetAdministrationShellById',
        request_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.DeleteAssetAdministrationShellByIdRpcRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.DeleteAssetAdministrationShellByIdRpcResponse.FromString,
        )


class AssetAdministrationShellRepositoryServiceServicer(object):
  # missing associated documentation comment in .proto file
  pass

  def GetAllAssetAdministrationShells(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def GetAssetAdministrationShellById(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def GetAllAssetAdministrationShellsByAssetId(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def GetAllAssetAdministrationShellsByIdShort(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def PostAssetAdministrationShell(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def PutAssetAdministrationShellById(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def DeleteAssetAdministrationShellById(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')


def add_AssetAdministrationShellRepositoryServiceServicer_to_server(servicer, server):
  rpc_method_handlers = {
      'GetAllAssetAdministrationShells': grpc.unary_unary_rpc_method_handler(
          servicer.GetAllAssetAdministrationShells,
          request_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsRpcRequest.FromString,
          response_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsRpcResponse.SerializeToString,
      ),
      'GetAssetAdministrationShellById': grpc.unary_unary_rpc_method_handler(
          servicer.GetAssetAdministrationShellById,
          request_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAssetAdministrationShellByIdRpcRequest.FromString,
          response_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAssetAdministrationShellByIdRpcResponse.SerializeToString,
      ),
      'GetAllAssetAdministrationShellsByAssetId': grpc.unary_unary_rpc_method_handler(
          servicer.GetAllAssetAdministrationShellsByAssetId,
          request_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsByAssetIdRpcRequest.FromString,
          response_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsByAssetIdRpcResponse.SerializeToString,
      ),
      'GetAllAssetAdministrationShellsByIdShort': grpc.unary_unary_rpc_method_handler(
          servicer.GetAllAssetAdministrationShellsByIdShort,
          request_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsByIdShortRpcRequest.FromString,
          response_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.GetAllAssetAdministrationShellsByIdShortRpcResponse.SerializeToString,
      ),
      'PostAssetAdministrationShell': grpc.unary_unary_rpc_method_handler(
          servicer.PostAssetAdministrationShell,
          request_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.PostAssetAdministrationShellRpcRequest.FromString,
          response_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.PostAssetAdministrationShellRpcResponse.SerializeToString,
      ),
      'PutAssetAdministrationShellById': grpc.unary_unary_rpc_method_handler(
          servicer.PutAssetAdministrationShellById,
          request_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.PutAssetAdministrationShellByIdRpcRequest.FromString,
          response_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.PutAssetAdministrationShellByIdRpcResponse.SerializeToString,
      ),
      'DeleteAssetAdministrationShellById': grpc.unary_unary_rpc_method_handler(
          servicer.DeleteAssetAdministrationShellById,
          request_deserializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.DeleteAssetAdministrationShellByIdRpcRequest.FromString,
          response_serializer=Protos_dot_Services_dot_AdminShellRepositoryService__pb2.DeleteAssetAdministrationShellByIdRpcResponse.SerializeToString,
      ),
  }
  generic_handler = grpc.method_handlers_generic_handler(
      'FSR.Aas.GRPC.Lib.V3.AssetAdministrationShellRepositoryService', rpc_method_handlers)
  server.add_generic_rpc_handlers((generic_handler,))