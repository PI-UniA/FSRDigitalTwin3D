using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;
using Grpc.Core;

namespace FSR.DigitalTwin.Client.Unity.GRPC.AAS {

    public class GrpcDigitalWorkspaceOperational : IDigitalWorkspaceOperational {
        
        private readonly Channel _rpcChannel;
        
        public GrpcDigitalWorkspaceOperational(Channel channel) {
            _rpcChannel = channel;
        }
    }

}