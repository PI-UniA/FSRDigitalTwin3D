using System.Reflection;

namespace FSR.DigitalTwin.App.GRPC.Common.Utils;

public class RpcAssembly {
    public static Assembly GetAssembly() {
        return typeof(RpcAssembly).Assembly;
    }
}