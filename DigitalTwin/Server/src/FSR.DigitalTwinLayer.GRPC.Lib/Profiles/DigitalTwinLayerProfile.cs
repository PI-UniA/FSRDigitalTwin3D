using AutoMapper;
using Google.Protobuf;

namespace FSR.DigitalTwinLayer.GRPC.Lib.Profiles;

public class DigitalTwinLayerProfile : Profile {
    public DigitalTwinLayerProfile() {
        CreateMap<byte[], StreamItem>().ConvertUsing(x => new StreamItem() { Payload = ByteString.CopyFrom(x) });
    }
}