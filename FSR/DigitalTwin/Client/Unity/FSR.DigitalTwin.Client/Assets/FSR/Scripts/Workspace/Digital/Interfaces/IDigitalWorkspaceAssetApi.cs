using System.Threading.Tasks;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces {
    public interface IDigitalWorkspaceAssetApi {
        bool HasAsset(string id);
        Task<bool> HasAssetAsync(string id);

        bool HasComponent(string id);
        Task<bool> HasComponentAsync(string id);

        string[] GetAssets();
        Task<string[]> GetAssetsAsync();

        string[] GetAssetComponents(string assetId);
        Task<string[]> GetAssetComponentsAsync(string assetId);

        bool SetComponentProperty<T>(string id, string prop, T value);
        Task<bool> SetComponentPropertyAsync<T>(string id, string prop, T value);

        T GetComponentProperty<T>(string id, string prop);
        Task<T> GetComponentPropertyAsync<T>(string id, string prop);
    }
}