using System.Threading.Tasks;
using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;
using Grpc.Core;

namespace FSR.DigitalTwin.Client.Unity.GRPC.AAS {

    public class GrpcDigitalWorkspaceApiBridge : IDigitalWorkspaceAssetApi
    {
        private readonly GrpcAdminShellApiServiceClient _client;

        public GrpcDigitalWorkspaceApiBridge(Channel channel) {
            _client = new(channel);
        }

        public string[] GetAssetComponents(string assetId)
        {
            throw new System.NotImplementedException();
        }

        public Task<string[]> GetAssetComponentsAsync(string assetId)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetAssets()
        {
            throw new System.NotImplementedException();
        }

        public Task<string[]> GetAssetsAsync()
        {
            throw new System.NotImplementedException();
        }

        public T GetComponentProperty<T>(string id, string prop)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetComponentPropertyAsync<T>(string id, string prop)
        {
            throw new System.NotImplementedException();
        }

        public bool HasAsset(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> HasAssetAsync(string id)
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