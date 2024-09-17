using System.Threading.Tasks;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces {
    public interface IDigitalWorkspaceEntityApi {
        bool HasEntity(string id);
        Task<bool> HasEntityAsync(string id);

        bool HasComponent(string id);
        Task<bool> HasComponentAsync(string id);

        string[] GetEntities();
        Task<string[]> GetEntitesAsync();

        string[] GetEntityComponents(string assetId);
        Task<string[]> GetEntityAssetComponentsAsync(string assetId);

        bool SetComponentProperty<T>(string id, string prop, T value);
        Task<bool> SetComponentPropertyAsync<T>(string id, string prop, T value);

        T GetComponentProperty<T>(string id, string prop);
        Task<T> GetComponentPropertyAsync<T>(string id, string prop);
    }
}