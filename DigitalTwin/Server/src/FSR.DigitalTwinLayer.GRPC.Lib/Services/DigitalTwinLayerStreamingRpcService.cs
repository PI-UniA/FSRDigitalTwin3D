using AutoMapper;
using FSR.DigitalTwin.App.Interfaces;
using FSR.DigitalTwinLayer.GRPC.Lib.Services.Connection;
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
        if (!_dataStreamingService.CreateValue(request.Name)) {
            response.Success = false;
        }
        return Task.FromResult(response);
    }

    public override Task<RemovePropertyResponse> RemoveProperty(RemovePropertyRequest request, ServerCallContext context)
    {
        var response = new RemovePropertyResponse() { Success = true };
        if (!_dataStreamingService.RemoveValue(request.Name)) {
            response.Success = false;
        }
        return Task.FromResult(response);
    }

    public override Task SubscribeStream(SubscribeStreamRequest request, IServerStreamWriter<StreamItem> responseStream, ServerCallContext context)
    {
        _dataStreamingService.SubscribeValue(request.Name, new AsyncRpcStreamWriter<byte[], StreamItem>(_mapper, responseStream));
        return Task.CompletedTask;
    }

    public override Task<UpdateValueResponse> UpdateValue(StreamItem request, ServerCallContext context)
    {
        return base.UpdateValue(request, context);
    }

}