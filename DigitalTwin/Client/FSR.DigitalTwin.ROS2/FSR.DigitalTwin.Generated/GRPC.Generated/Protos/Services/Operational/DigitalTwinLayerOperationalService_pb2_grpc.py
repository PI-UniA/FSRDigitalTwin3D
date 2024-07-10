# Generated by the gRPC Python protocol compiler plugin. DO NOT EDIT!
import grpc

from Protos.AasApiModels import V3_pb2 as Protos_dot_AasApiModels_dot_V3__pb2
from Protos.Services.Operational import DigitalTwinLayerOperationalService_pb2 as Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2


class DigitalTwinLayerOperationalServiceStub(object):
  # missing associated documentation comment in .proto file
  pass

  def __init__(self, channel):
    """Constructor.

    Args:
      channel: A grpc.Channel.
    """
    self.OpenOperationInvocationStream = channel.stream_stream(
        '/FSR.Aas.GRPC.Lib.V3.Operational.DigitalTwinLayerOperationalService/OpenOperationInvocationStream',
        request_serializer=Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2.OperationStatus.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2.OperationInvokeRequest.FromString,
        )
    self.OpenOperationResultStream = channel.stream_stream(
        '/FSR.Aas.GRPC.Lib.V3.Operational.DigitalTwinLayerOperationalService/OpenOperationResultStream',
        request_serializer=Protos_dot_AasApiModels_dot_V3__pb2.OperationResult.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2.OperationRequest.FromString,
        )
    self.OpenExecutionStateStream = channel.stream_stream(
        '/FSR.Aas.GRPC.Lib.V3.Operational.DigitalTwinLayerOperationalService/OpenExecutionStateStream',
        request_serializer=Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2.OperationStatus.SerializeToString,
        response_deserializer=Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2.OperationRequest.FromString,
        )


class DigitalTwinLayerOperationalServiceServicer(object):
  # missing associated documentation comment in .proto file
  pass

  def OpenOperationInvocationStream(self, request_iterator, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def OpenOperationResultStream(self, request_iterator, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')

  def OpenExecutionStateStream(self, request_iterator, context):
    # missing associated documentation comment in .proto file
    pass
    context.set_code(grpc.StatusCode.UNIMPLEMENTED)
    context.set_details('Method not implemented!')
    raise NotImplementedError('Method not implemented!')


def add_DigitalTwinLayerOperationalServiceServicer_to_server(servicer, server):
  rpc_method_handlers = {
      'OpenOperationInvocationStream': grpc.stream_stream_rpc_method_handler(
          servicer.OpenOperationInvocationStream,
          request_deserializer=Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2.OperationStatus.FromString,
          response_serializer=Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2.OperationInvokeRequest.SerializeToString,
      ),
      'OpenOperationResultStream': grpc.stream_stream_rpc_method_handler(
          servicer.OpenOperationResultStream,
          request_deserializer=Protos_dot_AasApiModels_dot_V3__pb2.OperationResult.FromString,
          response_serializer=Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2.OperationRequest.SerializeToString,
      ),
      'OpenExecutionStateStream': grpc.stream_stream_rpc_method_handler(
          servicer.OpenExecutionStateStream,
          request_deserializer=Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2.OperationStatus.FromString,
          response_serializer=Protos_dot_Services_dot_Operational_dot_DigitalTwinLayerOperationalService__pb2.OperationRequest.SerializeToString,
      ),
  }
  generic_handler = grpc.method_handlers_generic_handler(
      'FSR.Aas.GRPC.Lib.V3.Operational.DigitalTwinLayerOperationalService', rpc_method_handlers)
  server.add_generic_rpc_handlers((generic_handler,))