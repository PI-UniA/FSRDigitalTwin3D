// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/Services/PoseStreamingService.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection {

  /// <summary>Holder for reflection information generated from Protos/Services/PoseStreamingService.proto</summary>
  public static partial class PoseStreamingServiceReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/Services/PoseStreamingService.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PoseStreamingServiceReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CipQcm90b3MvU2VydmljZXMvUG9zZVN0cmVhbWluZ1NlcnZpY2UucHJvdG8S",
            "HUZTUi5EaWdpdGFsVHdpbkxheWVyLkdSUEMuTGliIkMKDFBvc2VMYW5kbWFy",
            "axIJCgF4GAEgASgCEgkKAXkYAiABKAISCQoBehgDIAEoAhISCgp2aXNpYmls",
            "aXR5GAQgASgCIhkKF0dldFBvc2VMYW5kbWFya3NSZXF1ZXN0Il4KGEdldFBv",
            "c2VMYW5kbWFya3NSZXNwb25zZRJCCg1wb3NlTGFuZG1hcmtzGAEgAygLMisu",
            "RlNSLkRpZ2l0YWxUd2luTGF5ZXIuR1JQQy5MaWIuUG9zZUxhbmRtYXJrIkgK",
            "EVdvcmxkUG9zZUxhbmRtYXJrEgkKAXgYASABKAISCQoBeRgCIAEoAhIJCgF6",
            "GAMgASgCEhIKCnZpc2liaWxpdHkYBCABKAIiHgocR2V0V29ybGRQb3NlTGFu",
            "ZG1hcmtzUmVxdWVzdCJtCh1HZXRXb3JsZFBvc2VMYW5kbWFya3NSZXNwb25z",
            "ZRJMChJ3b3JsZFBvc2VMYW5kbWFya3MYASADKAsyMC5GU1IuRGlnaXRhbFR3",
            "aW5MYXllci5HUlBDLkxpYi5Xb3JsZFBvc2VMYW5kbWFyazKqAgoNUG9zZVN0",
            "cmVhbWluZxKDAQoQR2V0UG9zZUxhbmRtYXJrcxI2LkZTUi5EaWdpdGFsVHdp",
            "bkxheWVyLkdSUEMuTGliLkdldFBvc2VMYW5kbWFya3NSZXF1ZXN0GjcuRlNS",
            "LkRpZ2l0YWxUd2luTGF5ZXIuR1JQQy5MaWIuR2V0UG9zZUxhbmRtYXJrc1Jl",
            "c3BvbnNlEpIBChVHZXRXb3JsZFBvc2VMYW5kbWFya3MSOy5GU1IuRGlnaXRh",
            "bFR3aW5MYXllci5HUlBDLkxpYi5HZXRXb3JsZFBvc2VMYW5kbWFya3NSZXF1",
            "ZXN0GjwuRlNSLkRpZ2l0YWxUd2luTGF5ZXIuR1JQQy5MaWIuR2V0V29ybGRQ",
            "b3NlTGFuZG1hcmtzUmVzcG9uc2VCNKoCMUZTUi5EaWdpdGFsVHdpbkxheWVy",
            "LkdSUEMuTGliLlNlcnZpY2VzLkNvbm5lY3Rpb25iBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseLandmark), global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseLandmark.Parser, new[]{ "X", "Y", "Z", "Visibility" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.GetPoseLandmarksRequest), global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.GetPoseLandmarksRequest.Parser, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.GetPoseLandmarksResponse), global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.GetPoseLandmarksResponse.Parser, new[]{ "PoseLandmarks" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.WorldPoseLandmark), global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.WorldPoseLandmark.Parser, new[]{ "X", "Y", "Z", "Visibility" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.GetWorldPoseLandmarksRequest), global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.GetWorldPoseLandmarksRequest.Parser, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.GetWorldPoseLandmarksResponse), global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.GetWorldPoseLandmarksResponse.Parser, new[]{ "WorldPoseLandmarks" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class PoseLandmark : pb::IMessage<PoseLandmark> {
    private static readonly pb::MessageParser<PoseLandmark> _parser = new pb::MessageParser<PoseLandmark>(() => new PoseLandmark());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<PoseLandmark> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseStreamingServiceReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PoseLandmark() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PoseLandmark(PoseLandmark other) : this() {
      x_ = other.x_;
      y_ = other.y_;
      z_ = other.z_;
      visibility_ = other.visibility_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public PoseLandmark Clone() {
      return new PoseLandmark(this);
    }

    /// <summary>Field number for the "x" field.</summary>
    public const int XFieldNumber = 1;
    private float x_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float X {
      get { return x_; }
      set {
        x_ = value;
      }
    }

    /// <summary>Field number for the "y" field.</summary>
    public const int YFieldNumber = 2;
    private float y_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Y {
      get { return y_; }
      set {
        y_ = value;
      }
    }

    /// <summary>Field number for the "z" field.</summary>
    public const int ZFieldNumber = 3;
    private float z_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Z {
      get { return z_; }
      set {
        z_ = value;
      }
    }

    /// <summary>Field number for the "visibility" field.</summary>
    public const int VisibilityFieldNumber = 4;
    private float visibility_;
    /// <summary>
    /// Optional visibility value
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Visibility {
      get { return visibility_; }
      set {
        visibility_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as PoseLandmark);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(PoseLandmark other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(X, other.X)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Y, other.Y)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Z, other.Z)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Visibility, other.Visibility)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (X != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(X);
      if (Y != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Y);
      if (Z != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Z);
      if (Visibility != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Visibility);
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (X != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(X);
      }
      if (Y != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(Y);
      }
      if (Z != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(Z);
      }
      if (Visibility != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(Visibility);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (X != 0F) {
        size += 1 + 4;
      }
      if (Y != 0F) {
        size += 1 + 4;
      }
      if (Z != 0F) {
        size += 1 + 4;
      }
      if (Visibility != 0F) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(PoseLandmark other) {
      if (other == null) {
        return;
      }
      if (other.X != 0F) {
        X = other.X;
      }
      if (other.Y != 0F) {
        Y = other.Y;
      }
      if (other.Z != 0F) {
        Z = other.Z;
      }
      if (other.Visibility != 0F) {
        Visibility = other.Visibility;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 13: {
            X = input.ReadFloat();
            break;
          }
          case 21: {
            Y = input.ReadFloat();
            break;
          }
          case 29: {
            Z = input.ReadFloat();
            break;
          }
          case 37: {
            Visibility = input.ReadFloat();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GetPoseLandmarksRequest : pb::IMessage<GetPoseLandmarksRequest> {
    private static readonly pb::MessageParser<GetPoseLandmarksRequest> _parser = new pb::MessageParser<GetPoseLandmarksRequest>(() => new GetPoseLandmarksRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetPoseLandmarksRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseStreamingServiceReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetPoseLandmarksRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetPoseLandmarksRequest(GetPoseLandmarksRequest other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetPoseLandmarksRequest Clone() {
      return new GetPoseLandmarksRequest(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetPoseLandmarksRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetPoseLandmarksRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetPoseLandmarksRequest other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  public sealed partial class GetPoseLandmarksResponse : pb::IMessage<GetPoseLandmarksResponse> {
    private static readonly pb::MessageParser<GetPoseLandmarksResponse> _parser = new pb::MessageParser<GetPoseLandmarksResponse>(() => new GetPoseLandmarksResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetPoseLandmarksResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseStreamingServiceReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetPoseLandmarksResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetPoseLandmarksResponse(GetPoseLandmarksResponse other) : this() {
      poseLandmarks_ = other.poseLandmarks_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetPoseLandmarksResponse Clone() {
      return new GetPoseLandmarksResponse(this);
    }

    /// <summary>Field number for the "poseLandmarks" field.</summary>
    public const int PoseLandmarksFieldNumber = 1;
    private static readonly pb::FieldCodec<global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseLandmark> _repeated_poseLandmarks_codec
        = pb::FieldCodec.ForMessage(10, global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseLandmark.Parser);
    private readonly pbc::RepeatedField<global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseLandmark> poseLandmarks_ = new pbc::RepeatedField<global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseLandmark>();
    /// <summary>
    /// List of pose landmarks
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseLandmark> PoseLandmarks {
      get { return poseLandmarks_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetPoseLandmarksResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetPoseLandmarksResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!poseLandmarks_.Equals(other.poseLandmarks_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= poseLandmarks_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      poseLandmarks_.WriteTo(output, _repeated_poseLandmarks_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += poseLandmarks_.CalculateSize(_repeated_poseLandmarks_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetPoseLandmarksResponse other) {
      if (other == null) {
        return;
      }
      poseLandmarks_.Add(other.poseLandmarks_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            poseLandmarks_.AddEntriesFrom(input, _repeated_poseLandmarks_codec);
            break;
          }
        }
      }
    }

  }

  public sealed partial class WorldPoseLandmark : pb::IMessage<WorldPoseLandmark> {
    private static readonly pb::MessageParser<WorldPoseLandmark> _parser = new pb::MessageParser<WorldPoseLandmark>(() => new WorldPoseLandmark());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<WorldPoseLandmark> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseStreamingServiceReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WorldPoseLandmark() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WorldPoseLandmark(WorldPoseLandmark other) : this() {
      x_ = other.x_;
      y_ = other.y_;
      z_ = other.z_;
      visibility_ = other.visibility_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public WorldPoseLandmark Clone() {
      return new WorldPoseLandmark(this);
    }

    /// <summary>Field number for the "x" field.</summary>
    public const int XFieldNumber = 1;
    private float x_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float X {
      get { return x_; }
      set {
        x_ = value;
      }
    }

    /// <summary>Field number for the "y" field.</summary>
    public const int YFieldNumber = 2;
    private float y_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Y {
      get { return y_; }
      set {
        y_ = value;
      }
    }

    /// <summary>Field number for the "z" field.</summary>
    public const int ZFieldNumber = 3;
    private float z_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Z {
      get { return z_; }
      set {
        z_ = value;
      }
    }

    /// <summary>Field number for the "visibility" field.</summary>
    public const int VisibilityFieldNumber = 4;
    private float visibility_;
    /// <summary>
    /// Optional visibility value
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Visibility {
      get { return visibility_; }
      set {
        visibility_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as WorldPoseLandmark);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(WorldPoseLandmark other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(X, other.X)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Y, other.Y)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Z, other.Z)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Visibility, other.Visibility)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (X != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(X);
      if (Y != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Y);
      if (Z != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Z);
      if (Visibility != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Visibility);
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (X != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(X);
      }
      if (Y != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(Y);
      }
      if (Z != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(Z);
      }
      if (Visibility != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(Visibility);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (X != 0F) {
        size += 1 + 4;
      }
      if (Y != 0F) {
        size += 1 + 4;
      }
      if (Z != 0F) {
        size += 1 + 4;
      }
      if (Visibility != 0F) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(WorldPoseLandmark other) {
      if (other == null) {
        return;
      }
      if (other.X != 0F) {
        X = other.X;
      }
      if (other.Y != 0F) {
        Y = other.Y;
      }
      if (other.Z != 0F) {
        Z = other.Z;
      }
      if (other.Visibility != 0F) {
        Visibility = other.Visibility;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 13: {
            X = input.ReadFloat();
            break;
          }
          case 21: {
            Y = input.ReadFloat();
            break;
          }
          case 29: {
            Z = input.ReadFloat();
            break;
          }
          case 37: {
            Visibility = input.ReadFloat();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GetWorldPoseLandmarksRequest : pb::IMessage<GetWorldPoseLandmarksRequest> {
    private static readonly pb::MessageParser<GetWorldPoseLandmarksRequest> _parser = new pb::MessageParser<GetWorldPoseLandmarksRequest>(() => new GetWorldPoseLandmarksRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetWorldPoseLandmarksRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseStreamingServiceReflection.Descriptor.MessageTypes[4]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetWorldPoseLandmarksRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetWorldPoseLandmarksRequest(GetWorldPoseLandmarksRequest other) : this() {
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetWorldPoseLandmarksRequest Clone() {
      return new GetWorldPoseLandmarksRequest(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetWorldPoseLandmarksRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetWorldPoseLandmarksRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetWorldPoseLandmarksRequest other) {
      if (other == null) {
        return;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
        }
      }
    }

  }

  public sealed partial class GetWorldPoseLandmarksResponse : pb::IMessage<GetWorldPoseLandmarksResponse> {
    private static readonly pb::MessageParser<GetWorldPoseLandmarksResponse> _parser = new pb::MessageParser<GetWorldPoseLandmarksResponse>(() => new GetWorldPoseLandmarksResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetWorldPoseLandmarksResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.PoseStreamingServiceReflection.Descriptor.MessageTypes[5]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetWorldPoseLandmarksResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetWorldPoseLandmarksResponse(GetWorldPoseLandmarksResponse other) : this() {
      worldPoseLandmarks_ = other.worldPoseLandmarks_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetWorldPoseLandmarksResponse Clone() {
      return new GetWorldPoseLandmarksResponse(this);
    }

    /// <summary>Field number for the "worldPoseLandmarks" field.</summary>
    public const int WorldPoseLandmarksFieldNumber = 1;
    private static readonly pb::FieldCodec<global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.WorldPoseLandmark> _repeated_worldPoseLandmarks_codec
        = pb::FieldCodec.ForMessage(10, global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.WorldPoseLandmark.Parser);
    private readonly pbc::RepeatedField<global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.WorldPoseLandmark> worldPoseLandmarks_ = new pbc::RepeatedField<global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.WorldPoseLandmark>();
    /// <summary>
    /// List of world pose landmarks
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection.WorldPoseLandmark> WorldPoseLandmarks {
      get { return worldPoseLandmarks_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetWorldPoseLandmarksResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetWorldPoseLandmarksResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!worldPoseLandmarks_.Equals(other.worldPoseLandmarks_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= worldPoseLandmarks_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      worldPoseLandmarks_.WriteTo(output, _repeated_worldPoseLandmarks_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += worldPoseLandmarks_.CalculateSize(_repeated_worldPoseLandmarks_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetWorldPoseLandmarksResponse other) {
      if (other == null) {
        return;
      }
      worldPoseLandmarks_.Add(other.worldPoseLandmarks_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            worldPoseLandmarks_.AddEntriesFrom(input, _repeated_worldPoseLandmarks_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code