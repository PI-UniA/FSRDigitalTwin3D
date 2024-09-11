using FSR.DigitalTwin.App.GRPC.Services.RPC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FSR.DigitalTwin.App.GRPC.Common.Utils;

public static class GrpcService {
    public static void MapAppGrpcServices(this IEndpointRouteBuilder endpoints) {
        endpoints.MapGrpcService<AssetAdministrationShellRepositoryRpcService>();
        endpoints.MapGrpcService<SubmodelRepositoryRpcService>();
        endpoints.MapGrpcService<AssetAdministrationShellRpcService>();
        endpoints.MapGrpcService<SubmodelRpcService>();
        endpoints.MapGrpcService<DigitalTwinClientConnectionRpcService>();
    }

    public static void AddAppServices(this IServiceCollection services) {
        // TODO
    }
}