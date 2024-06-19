# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: Protos/Services/Connection/DigitalTwinLayerStreamingService.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()


from Protos import DigitalTwinLayerModels_pb2 as Protos_dot_DigitalTwinLayerModels__pb2


DESCRIPTOR = _descriptor.FileDescriptor(
  name='Protos/Services/Connection/DigitalTwinLayerStreamingService.proto',
  package='FSR.DigitalTwinLayer.GRPC.Lib',
  syntax='proto3',
  serialized_options=_b('\252\0021FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection'),
  serialized_pb=_b('\nAProtos/Services/Connection/DigitalTwinLayerStreamingService.proto\x12\x1d\x46SR.DigitalTwinLayer.GRPC.Lib\x1a#Protos/DigitalTwinLayerModels.proto\"%\n\x15\x43reatePropertyRequest\x12\x0c\n\x04name\x18\x01 \x01(\t\")\n\x16\x43reatePropertyResponse\x12\x0f\n\x07success\x18\x01 \x01(\x08\"%\n\x15RemovePropertyRequest\x12\x0c\n\x04name\x18\x01 \x01(\t\")\n\x16RemovePropertyResponse\x12\x0f\n\x07success\x18\x01 \x01(\x08\"&\n\x16SubscribeStreamRequest\x12\x0c\n\x04name\x18\x01 \x01(\t\"&\n\x13UpdateValueResponse\x12\x0f\n\x07success\x18\x01 \x01(\x08\x32\x85\x04\n DigitalTwinLayerStreamingService\x12}\n\x0e\x43reateProperty\x12\x34.FSR.DigitalTwinLayer.GRPC.Lib.CreatePropertyRequest\x1a\x35.FSR.DigitalTwinLayer.GRPC.Lib.CreatePropertyResponse\x12}\n\x0eRemoveProperty\x12\x34.FSR.DigitalTwinLayer.GRPC.Lib.RemovePropertyRequest\x1a\x35.FSR.DigitalTwinLayer.GRPC.Lib.RemovePropertyResponse\x12u\n\x0fSubscribeStream\x12\x35.FSR.DigitalTwinLayer.GRPC.Lib.SubscribeStreamRequest\x1a).FSR.DigitalTwinLayer.GRPC.Lib.StreamItem0\x01\x12l\n\x0bUpdateValue\x12).FSR.DigitalTwinLayer.GRPC.Lib.StreamItem\x1a\x32.FSR.DigitalTwinLayer.GRPC.Lib.UpdateValueResponseB4\xaa\x02\x31\x46SR.DigitalTwinLayer.GRPC.Lib.Services.Connectionb\x06proto3')
  ,
  dependencies=[Protos_dot_DigitalTwinLayerModels__pb2.DESCRIPTOR,])




_CREATEPROPERTYREQUEST = _descriptor.Descriptor(
  name='CreatePropertyRequest',
  full_name='FSR.DigitalTwinLayer.GRPC.Lib.CreatePropertyRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='name', full_name='FSR.DigitalTwinLayer.GRPC.Lib.CreatePropertyRequest.name', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=137,
  serialized_end=174,
)


_CREATEPROPERTYRESPONSE = _descriptor.Descriptor(
  name='CreatePropertyResponse',
  full_name='FSR.DigitalTwinLayer.GRPC.Lib.CreatePropertyResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='success', full_name='FSR.DigitalTwinLayer.GRPC.Lib.CreatePropertyResponse.success', index=0,
      number=1, type=8, cpp_type=7, label=1,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=176,
  serialized_end=217,
)


_REMOVEPROPERTYREQUEST = _descriptor.Descriptor(
  name='RemovePropertyRequest',
  full_name='FSR.DigitalTwinLayer.GRPC.Lib.RemovePropertyRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='name', full_name='FSR.DigitalTwinLayer.GRPC.Lib.RemovePropertyRequest.name', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=219,
  serialized_end=256,
)


_REMOVEPROPERTYRESPONSE = _descriptor.Descriptor(
  name='RemovePropertyResponse',
  full_name='FSR.DigitalTwinLayer.GRPC.Lib.RemovePropertyResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='success', full_name='FSR.DigitalTwinLayer.GRPC.Lib.RemovePropertyResponse.success', index=0,
      number=1, type=8, cpp_type=7, label=1,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=258,
  serialized_end=299,
)


_SUBSCRIBESTREAMREQUEST = _descriptor.Descriptor(
  name='SubscribeStreamRequest',
  full_name='FSR.DigitalTwinLayer.GRPC.Lib.SubscribeStreamRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='name', full_name='FSR.DigitalTwinLayer.GRPC.Lib.SubscribeStreamRequest.name', index=0,
      number=1, type=9, cpp_type=9, label=1,
      has_default_value=False, default_value=_b("").decode('utf-8'),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=301,
  serialized_end=339,
)


_UPDATEVALUERESPONSE = _descriptor.Descriptor(
  name='UpdateValueResponse',
  full_name='FSR.DigitalTwinLayer.GRPC.Lib.UpdateValueResponse',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='success', full_name='FSR.DigitalTwinLayer.GRPC.Lib.UpdateValueResponse.success', index=0,
      number=1, type=8, cpp_type=7, label=1,
      has_default_value=False, default_value=False,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=341,
  serialized_end=379,
)

DESCRIPTOR.message_types_by_name['CreatePropertyRequest'] = _CREATEPROPERTYREQUEST
DESCRIPTOR.message_types_by_name['CreatePropertyResponse'] = _CREATEPROPERTYRESPONSE
DESCRIPTOR.message_types_by_name['RemovePropertyRequest'] = _REMOVEPROPERTYREQUEST
DESCRIPTOR.message_types_by_name['RemovePropertyResponse'] = _REMOVEPROPERTYRESPONSE
DESCRIPTOR.message_types_by_name['SubscribeStreamRequest'] = _SUBSCRIBESTREAMREQUEST
DESCRIPTOR.message_types_by_name['UpdateValueResponse'] = _UPDATEVALUERESPONSE
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

CreatePropertyRequest = _reflection.GeneratedProtocolMessageType('CreatePropertyRequest', (_message.Message,), {
  'DESCRIPTOR' : _CREATEPROPERTYREQUEST,
  '__module__' : 'Protos.Services.Connection.DigitalTwinLayerStreamingService_pb2'
  # @@protoc_insertion_point(class_scope:FSR.DigitalTwinLayer.GRPC.Lib.CreatePropertyRequest)
  })
_sym_db.RegisterMessage(CreatePropertyRequest)

CreatePropertyResponse = _reflection.GeneratedProtocolMessageType('CreatePropertyResponse', (_message.Message,), {
  'DESCRIPTOR' : _CREATEPROPERTYRESPONSE,
  '__module__' : 'Protos.Services.Connection.DigitalTwinLayerStreamingService_pb2'
  # @@protoc_insertion_point(class_scope:FSR.DigitalTwinLayer.GRPC.Lib.CreatePropertyResponse)
  })
_sym_db.RegisterMessage(CreatePropertyResponse)

RemovePropertyRequest = _reflection.GeneratedProtocolMessageType('RemovePropertyRequest', (_message.Message,), {
  'DESCRIPTOR' : _REMOVEPROPERTYREQUEST,
  '__module__' : 'Protos.Services.Connection.DigitalTwinLayerStreamingService_pb2'
  # @@protoc_insertion_point(class_scope:FSR.DigitalTwinLayer.GRPC.Lib.RemovePropertyRequest)
  })
_sym_db.RegisterMessage(RemovePropertyRequest)

RemovePropertyResponse = _reflection.GeneratedProtocolMessageType('RemovePropertyResponse', (_message.Message,), {
  'DESCRIPTOR' : _REMOVEPROPERTYRESPONSE,
  '__module__' : 'Protos.Services.Connection.DigitalTwinLayerStreamingService_pb2'
  # @@protoc_insertion_point(class_scope:FSR.DigitalTwinLayer.GRPC.Lib.RemovePropertyResponse)
  })
_sym_db.RegisterMessage(RemovePropertyResponse)

SubscribeStreamRequest = _reflection.GeneratedProtocolMessageType('SubscribeStreamRequest', (_message.Message,), {
  'DESCRIPTOR' : _SUBSCRIBESTREAMREQUEST,
  '__module__' : 'Protos.Services.Connection.DigitalTwinLayerStreamingService_pb2'
  # @@protoc_insertion_point(class_scope:FSR.DigitalTwinLayer.GRPC.Lib.SubscribeStreamRequest)
  })
_sym_db.RegisterMessage(SubscribeStreamRequest)

UpdateValueResponse = _reflection.GeneratedProtocolMessageType('UpdateValueResponse', (_message.Message,), {
  'DESCRIPTOR' : _UPDATEVALUERESPONSE,
  '__module__' : 'Protos.Services.Connection.DigitalTwinLayerStreamingService_pb2'
  # @@protoc_insertion_point(class_scope:FSR.DigitalTwinLayer.GRPC.Lib.UpdateValueResponse)
  })
_sym_db.RegisterMessage(UpdateValueResponse)


DESCRIPTOR._options = None

_DIGITALTWINLAYERSTREAMINGSERVICE = _descriptor.ServiceDescriptor(
  name='DigitalTwinLayerStreamingService',
  full_name='FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService',
  file=DESCRIPTOR,
  index=0,
  serialized_options=None,
  serialized_start=382,
  serialized_end=899,
  methods=[
  _descriptor.MethodDescriptor(
    name='CreateProperty',
    full_name='FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService.CreateProperty',
    index=0,
    containing_service=None,
    input_type=_CREATEPROPERTYREQUEST,
    output_type=_CREATEPROPERTYRESPONSE,
    serialized_options=None,
  ),
  _descriptor.MethodDescriptor(
    name='RemoveProperty',
    full_name='FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService.RemoveProperty',
    index=1,
    containing_service=None,
    input_type=_REMOVEPROPERTYREQUEST,
    output_type=_REMOVEPROPERTYRESPONSE,
    serialized_options=None,
  ),
  _descriptor.MethodDescriptor(
    name='SubscribeStream',
    full_name='FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService.SubscribeStream',
    index=2,
    containing_service=None,
    input_type=_SUBSCRIBESTREAMREQUEST,
    output_type=Protos_dot_DigitalTwinLayerModels__pb2._STREAMITEM,
    serialized_options=None,
  ),
  _descriptor.MethodDescriptor(
    name='UpdateValue',
    full_name='FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerStreamingService.UpdateValue',
    index=3,
    containing_service=None,
    input_type=Protos_dot_DigitalTwinLayerModels__pb2._STREAMITEM,
    output_type=_UPDATEVALUERESPONSE,
    serialized_options=None,
  ),
])
_sym_db.RegisterServiceDescriptor(_DIGITALTWINLAYERSTREAMINGSERVICE)

DESCRIPTOR.services_by_name['DigitalTwinLayerStreamingService'] = _DIGITALTWINLAYERSTREAMINGSERVICE

# @@protoc_insertion_point(module_scope)
