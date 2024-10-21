using FSR.DigitalTwin.App.Interfaces;
using FSR.DigitalTwin.App.Services;
using FSR.DigitalTwinLayer.GRPC.Lib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FSR.DigitalTwinLayer.GRPC.Lib.Common.Utils;

public class DependencyInjection 
{
    public static void AddServices(IServiceCollection services) {
        services.AddSingleton<IDigitalTwinLayerService, DigitalTwinLayerService>();
        services.AddSingleton<IDataStreamingService, DataStreamingService>();
        services.AddSingleton<IFaceExpressionService, FaceExpressionService>();
        services.AddSingleton<IPoseTrackingService, PoseTrackingService>();
    }

}

public static class GrpcService {
    public static void MapDTLayerGrpcServices(this IEndpointRouteBuilder endpoints) {
        endpoints.MapGrpcService<DigitalTwinLayerOperationalRpcService>();
        endpoints.MapGrpcService<DigitalTwinLayerConnectionRpcService>();
        endpoints.MapGrpcService<DigitalTwinLayerStreamingRpcService>();
        endpoints.MapGrpcService<PoseStreamingRpcService>();
        endpoints.MapGrpcService<PoseRpcService>();
    }
}