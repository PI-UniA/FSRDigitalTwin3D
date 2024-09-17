using System.Threading.Tasks;
using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;
using Grpc.Core;

namespace FSR.DigitalTwin.Client.Unity.GRPC.AAS {

    public class GrpcDigitalWorkspaceApiBridge : IDigitalWorkspaceEntityApi
    {
        private readonly GrpcAdminShellApiServiceClient _client;

        public GrpcDigitalWorkspaceApiBridge(Channel channel) {
            _client = new(channel);
        }

        public T GetComponentProperty<T>(string id, string prop)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetComponentPropertyAsync<T>(string id, string prop)
        {
            throw new System.NotImplementedException();
        }

        public Task<string[]> GetEntitesAsync()
        {
            throw new System.NotImplementedException();
        }

        public string[] GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Task<string[]> GetEntityAssetComponentsAsync(string assetId)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetEntityComponents(string assetId)
        {
            throw new System.NotImplementedException();
        }

        public bool HasComponent(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> HasComponentAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool HasEntity(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> HasEntityAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool SetComponentProperty<T>(string id, string prop, T value)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SetComponentPropertyAsync<T>(string id, string prop, T value)
        {
            throw new System.NotImplementedException();
        }
    }

}