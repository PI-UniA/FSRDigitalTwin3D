using AutoMapper;
using Google.Protobuf;

namespace FSR.DigitalTwinLayer.GRPC.Lib.Profiles;

public class DigitalTwinLayerProfile : Profile {
    public DigitalTwinLayerProfile() {
        _MapStreamItem();
    }

    private void _MapStreamItem() {
        CreateMap<byte[], StreamItem>().ConvertUsing(x => new StreamItem() { Payload = ByteString.CopyFrom(x) });
        CreateMap<int[], StreamItem>()
            .AfterMap((x, y) => { y.PayloadI32.AddRange(x); })
            .ConvertUsing(x => new StreamItem() { Type = StreamItemType.Int32 });
        CreateMap<float[], StreamItem>()
            .AfterMap((x, y) => { y.PayloadF32.AddRange(x); })
            .ConvertUsing(x => new StreamItem() { Type = StreamItemType.Float32 });
    }
}