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
        var response = new CreatePropertyResponse() { Success = true, Value = request.InitialValue };
        var initialValue = request.InitialValue.Payload.Memory.ToArray();
        if (!_dataStreamingService.CreateProperty<byte[]>(request.Name)) {
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

    public override Task<UpdateValueResponse> UpdateValue(UpdateValueRequest request, ServerCallContext context)
    {
        var response = new UpdateValueResponse() { Success = true, Value = request.Value };
        if (!_dataStreamingService.HasProperty(request.Name)) {
            response.Success = false;
            return Task.FromResult(response);
        }
        var value = request.Value.Payload.Memory.ToArray();
        _dataStreamingService.UpdateValue(request.Name, value);
        return Task.FromResult(response);
    }

    public override Task<GetValueResponse> GetValue(GetValueRequest request, ServerCallContext context)
    {
        GetValueResponse response = new() { Success = false };
        if (!_dataStreamingService.HasProperty(request.Name)) {
            return Task.FromResult(response);
        }
        var value = _dataStreamingService.GetValue<byte[]>(request.Name);
        response.Value = new StreamItem { Payload = ByteString.CopyFrom(value) };
        response.Success = true;
        return Task.FromResult(response);
    }

    public override async Task<StreamValueResponse> StreamValue(IAsyncStreamReader<UpdateValueRequest> requestStream, ServerCallContext context)
    {
        while (await requestStream.MoveNext()) {
            var request = requestStream.Current;
            if (request.Terminated) {
                return new StreamValueResponse { Terminated = true };
            }
            _dataStreamingService.UpdateValue(request.Name, request);
        }
        return new StreamValueResponse { Terminated = false };
    }
}
