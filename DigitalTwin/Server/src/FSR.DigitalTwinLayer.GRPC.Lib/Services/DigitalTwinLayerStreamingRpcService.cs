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
        return request.InitialValue.Type switch
        {
            StreamItemType.Byte => CreateProperty<byte>(request, context),
            StreamItemType.Int32 => CreateProperty<int>(request, context),
            StreamItemType.Float32 => CreateProperty<float>(request, context),
            _ => Task.FromResult(new CreatePropertyResponse() { Success = false }),
        };
    }

    private Task<CreatePropertyResponse> CreateProperty<T>(CreatePropertyRequest request, ServerCallContext context) {
        var response = new CreatePropertyResponse() { Success = true, Value = request.InitialValue };
        var initialValue = request.InitialValue.Payload.Memory.ToArray();
        if (!_dataStreamingService.CreateProperty<T[]>(request.Name)) {
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
        switch (request.Value.Type) {
            case StreamItemType.Byte: { 
                var value = request.Value.Payload.Memory.ToArray();
                _dataStreamingService.UpdateValue(request.Name, value);
            } break;
            case StreamItemType.Int32: { 
                var value = request.Value.PayloadI32.ToArray();
                _dataStreamingService.UpdateValue(request.Name, value);
            } break;
            case StreamItemType.Float32: { 
                var value = request.Value.PayloadF32.ToArray();
                _dataStreamingService.UpdateValue(request.Name, value);
            } break;
        }
        return Task.FromResult(response);
    }

    public override Task<GetValueResponse> GetValue(GetValueRequest request, ServerCallContext context)
    {
        GetValueResponse response = new() { Success = false };
        if (!_dataStreamingService.HasProperty(request.Name)) {
            return Task.FromResult(response);
        }
        StreamItem si = new() { Type = request.Type };
        switch (request.Type) {
            case StreamItemType.Byte: { si.Payload = ByteString.CopyFrom(_dataStreamingService.GetValue<byte[]>(request.Name)); }
                break;
            case StreamItemType.Int32: { si.PayloadI32.AddRange(_dataStreamingService.GetValue<int[]>(request.Name)); }
                break;
            case StreamItemType.Float32: { si.PayloadF32.AddRange(_dataStreamingService.GetValue<float[]>(request.Name)); }
                break;
        }
        response.Value = si;
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
