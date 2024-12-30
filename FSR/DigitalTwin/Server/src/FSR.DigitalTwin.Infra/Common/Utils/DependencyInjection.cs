using Microsoft.Extensions.DependencyInjection;
using FSR.DigitalTwin.App.Common.Network;
using FSR.DigitalTwin.Infra.ROS2;

namespace FSR.DigitalTwin.Infra.Common.Utils;

public static class DependencyInjection {
    public static void AddInfra(this IServiceCollection services) {
        // ROS2
        services.AddTransient<IRosConnection, RosWebSocketConnection>();
        // Insert more infrastructure if needed...
    }
}