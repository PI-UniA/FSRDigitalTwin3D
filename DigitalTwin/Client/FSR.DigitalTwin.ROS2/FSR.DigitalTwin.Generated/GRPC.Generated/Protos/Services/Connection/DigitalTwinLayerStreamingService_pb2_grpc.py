# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
import grpc

from Protos import DigitalTwinLayerModels_pb2 as Protos_dot_DigitalTwinLayerModels__pb2
from Protos.Services.Connection import DigitalTwinLayerStreamingService_pb2 as Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2


class DigitalTwinLayerStreamingServiceStub(object):
  # missing associated documentation comment in .proto file
  pass

  def __init__(self, channel):
    """Constructor.

    Args:
      channel: A grpc.Channel.
    """
    self.CreateProperty = channel.unary_unary(
        '/FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService/CreateProperty',
        request_serializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.CreatePropertyRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.CreatePropertyResponse.FromString,
        )
    self.GetProperty = channel.unary_unary(
        '/FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService/GetProperty',
        request_serializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.GetPropertyRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.GetPropertyResponse.FromString,
        )
    self.RemoveProperty = channel.unary_unary(
        '/FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService/RemoveProperty',
        request_serializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.RemovePropertyRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.RemovePropertyResponse.FromString,
        )
    self.SubscribeProperty = channel.unary_stream(
        '/FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService/SubscribeProperty',
        request_serializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.SubscribePropertyRequest.SerializeToString,
        response_deserializer=Protos_dot_DigitalTwinLayerModels__pb2.StreamItem.FromString,
        )
    self.UpdateProperty = channel.unary_unary(
        '/FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService/UpdateProperty',
        request_serializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.UpdatePropertyRequest.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.UpdatePropertyResponse.FromString,
        )


class DigitalTwinLayerStreamingServiceServicer(object):
  # missing associated documentation comment in .proto file
  pass

  def CreateProperty(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def GetProperty(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def RemoveProperty(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def SubscribeProperty(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def UpdateProperty(self, request, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')


def add_DigitalTwinLayerStreamingServiceServicer_to_server(servicer, server):
  rpc_method_handlers = {
      'CreateProperty': grpc.unary_unary_rpc_method_handler(
          servicer.CreateProperty,
          request_deserializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.CreatePropertyRequest.FromString,
          response_serializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.CreatePropertyResponse.SerializeToString,
      ),
      'GetProperty': grpc.unary_unary_rpc_method_handler(
          servicer.GetProperty,
          request_deserializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.GetPropertyRequest.FromString,
          response_serializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.GetPropertyResponse.SerializeToString,
      ),
      'RemoveProperty': grpc.unary_unary_rpc_method_handler(
          servicer.RemoveProperty,
          request_deserializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.RemovePropertyRequest.FromString,
          response_serializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.RemovePropertyResponse.SerializeToString,
      ),
      'SubscribeProperty': grpc.unary_stream_rpc_method_handler(
          servicer.SubscribeProperty,
          request_deserializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.SubscribePropertyRequest.FromString,
          response_serializer=Protos_dot_DigitalTwinLayerModels__pb2.StreamItem.SerializeToString,
      ),
      'UpdateProperty': grpc.unary_unary_rpc_method_handler(
          servicer.UpdateProperty,
          request_deserializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.UpdatePropertyRequest.FromString,
          response_serializer=Protos_dot_Services_dot_Connection_dot_DigitalTwinLayerStreamingService__pb2.UpdatePropertyResponse.SerializeToString,
      ),
  }
  generic_handler = grpc.method_handlers_generic_handler(
      'FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService', rpc_method_handlers)
  server.add_generic_rpc_handlers((generic_handler,))
