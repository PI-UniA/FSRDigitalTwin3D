using System.Threading.Tasks;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces {

    public interface IDigitalTwinAssetComponent {
        IDigitalTwinAsset IDigitalTwinAsset { get; init; }
        string Id { get; init; }
        bool HasConnection { get; }

        bool SetProperty<T>(string prop, T value);
        Task<bool> SetPropertyAsync<T>(string prop, T value);

        T GetProperty<T>(string prop);
        Task<T> GetPropertyAsync<T>(string prop);
    }

}