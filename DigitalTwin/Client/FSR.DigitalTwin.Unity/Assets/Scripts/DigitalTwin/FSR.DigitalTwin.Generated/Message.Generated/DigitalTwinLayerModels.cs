// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/DigitalTwinLayerModels.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace FSR.DigitalTwinLayer.GRPC.Lib {

  /// <summary>Holder for reflection information generated from Protos/DigitalTwinLayerModels.proto</summary>
  public static partial class DigitalTwinLayerModelsReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/DigitalTwinLayerModels.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DigitalTwinLayerModelsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiNQcm90b3MvRGlnaXRhbFR3aW5MYXllck1vZGVscy5wcm90bxIdRlNSLkRp",
            "Z2l0YWxUd2luTGF5ZXIuR1JQQy5MaWIqTQoURGlnaXRhbFR3aW5MYXllclR5",
            "cGUSGQoVRFRfTEFZRVJfVFlQRV9WSVJUVUFMEAASGgoWRFRfTEFZRVJfVFlQ",
            "RV9QSFlTSUNBTBABQiCqAh1GU1IuRGlnaXRhbFR3aW5MYXllci5HUlBDLkxp",
            "YmIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::FSR.DigitalTwinLayer.GRPC.Lib.DigitalTwinLayerType), }, null));
    }
    #endregion

  }
  #region Enums
  public enum DigitalTwinLayerType {
    [pbr::OriginalName("DT_LAYER_TYPE_VIRTUAL")] DtLayerTypeVirtual = 0,
    [pbr::OriginalName("DT_LAYER_TYPE_PHYSICAL")] DtLayerTypePhysical = 1,
  }

  #endregion

}

#endregion Designer generated code
