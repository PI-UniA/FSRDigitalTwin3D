# -*- coding: utf-8 -*-
# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: Protos/DigitalTwinLayerModels.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf.internal import enum_type_wrapper
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='Protos/DigitalTwinLayerModels.proto',
  package='FSR.DigitalTwinLayer.GRPC.Lib',
  syntax='proto3',
  serialized_options=_b('\252\002\035FSR.DigitalTwinLayer.GRPC.Lib'),
  serialized_pb=_b('\n#Protos/DigitalTwinLayerModels.proto\x12\x1d\x46SR.DigitalTwinLayer.GRPC.Lib\"\x1d\n\nStreamItem\x12\x0f\n\x07payload\x18\x01 \x01(\x0c*M\n\x14\x44igitalTwinLayerType\x12\x19\n\x15\x44T_LAYER_TYPE_VIRTUAL\x10\x00\x12\x1a\n\x16\x44T_LAYER_TYPE_PHYSICAL\x10\x01\x42 \xaa\x02\x1d\x46SR.DigitalTwinLayer.GRPC.Libb\x06proto3')
)

_DIGITALTWINLAYERTYPE = _descriptor.EnumDescriptor(
  name='DigitalTwinLayerType',
  full_name='FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerType',
  filename=None,
  file=DESCRIPTOR,
  values=[
    _descriptor.EnumValueDescriptor(
      name='DT_LAYER_TYPE_VIRTUAL', index=0, number=0,
      serialized_options=None,
      type=None),
    _descriptor.EnumValueDescriptor(
      name='DT_LAYER_TYPE_PHYSICAL', index=1, number=1,
      serialized_options=None,
      type=None),
  ],
  containing_type=None,
  serialized_options=None,
  serialized_start=101,
  serialized_end=178,
)
_sym_db.RegisterEnumDescriptor(_DIGITALTWINLAYERTYPE)

DigitalTwinLayerType = enum_type_wrapper.EnumTypeWrapper(_DIGITALTWINLAYERTYPE)
DT_LAYER_TYPE_VIRTUAL = 0
DT_LAYER_TYPE_PHYSICAL = 1



_STREAMITEM = _descriptor.Descriptor(
  name='StreamItem',
  full_name='FSR.DigitalTwinLayer.GRPC.Lib.StreamItem',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='payload', full_name='FSR.DigitalTwinLayer.GRPC.Lib.StreamItem.payload', index=0,
      number=1, type=12, cpp_type=9, label=1,
      has_default_value=False, default_value=_b(""),
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
  serialized_start=70,
  serialized_end=99,
)

DESCRIPTOR.message_types_by_name['StreamItem'] = _STREAMITEM
DESCRIPTOR.enum_types_by_name['DigitalTwinLayerType'] = _DIGITALTWINLAYERTYPE
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

StreamItem = _reflection.GeneratedProtocolMessageType('StreamItem', (_message.Message,), {
  'DESCRIPTOR' : _STREAMITEM,
  '__module__' : 'Protos.DigitalTwinLayerModels_pb2'
  # @@protoc_insertion_point(class_scope:FSR.DigitalTwinLayer.GRPC.Lib.StreamItem)
  })
_sym_db.RegisterMessage(StreamItem)


DESCRIPTOR._options = None
# @@protoc_insertion_point(module_scope)