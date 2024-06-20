using AutoMapper;
using FSR.DigitalTwin.App.Interfaces;
using FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection;
using Google.Protobuf;
using Grpc.Core;

namespace FSR.DigitalTwinLayer.GRPC.Lib.Services;

public class DigitalTwinLayerStreamingRpcService : DigitalTwinLayerStreamingService.DigitalTwinLayerStreamingServiceBase {

    private readonly IDataStreamingService _dataStreamingService;
    private readonly IMapper _mapper;

    public DigitalTwinLayerStreamingRpcService(IDataStreamingService dataStreamingService, IMapper mapper) {
        _dataStreamingService = dataStreamingService;
        _mapper = mapper;
    }

    public override Task<CreatePropertyResponse> CreateProperty(CreatePropertyRequest request, ServerCallContext context)
    {
        var response = new CreatePropertyResponse() { Success = true };
        var initialValue = request.InitialValue.Memory.ToArray();
        if (!_dataStreamingService.CreateProperty(request.Name)) {
            response.Success = false;
        }
        else {
            _dataStreamingService.UpdateValue(request.Name, initialValue);
        }
        return Task.FromResult(response);
    }

    public override Task<RemovePropertyResponse> RemoveProperty(RemovePropertyRequest request, ServerCallContext context)
    {
        var response = new RemovePropertyResponse() { Success = true };
        if (!_dataStreamingService.RemoveProperty(request.Name)) {
            response.Success = false;
        }
        return Task.FromResult(response);
    }

    public override Task SubscribeProperty(SubscribePropertyRequest request, IServerStreamWriter<StreamItem> responseStream, ServerCallContext context)
    {
        _dataStreamingService.SubscribeProperty(request.Name, new AsyncRpcStreamWriter<byte[], StreamItem>(_mapper, responseStream));
        return Task.CompletedTask;
    }

    public override Task<UpdatePropertyResponse> UpdateProperty(UpdatePropertyRequest request, ServerCallContext context)
    {
        var response = new UpdatePropertyResponse() { Success = true };
        var value = request.Value.Memory.ToArray();
        _dataStreamingService.UpdateValue(request.Name, value);
        return Task.FromResult(response);
    }

    public override Task<GetPropertyResponse> GetProperty(GetPropertyRequest request, ServerCallContext context)
    {
        var response = new GetPropertyResponse() { Success = true };
        if (!_dataStreamingService.HasProperty(request.Name)) {
            response.Success = false;
            return Task.FromResult(response);
        }
        var value = _dataStreamingService.GetValue(request.Name);
        response.Value = ByteString.CopyFrom(value);
        return Task.FromResult(response);
    }

}