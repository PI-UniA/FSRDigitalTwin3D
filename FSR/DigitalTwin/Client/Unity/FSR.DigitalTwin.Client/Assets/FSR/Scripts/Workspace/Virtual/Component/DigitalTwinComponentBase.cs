using System.Threading.Tasks;
using FSR.DigitalTwin.Client.Unity.Workspace.Digital.Interfaces;

namespace FSR.DigitalTwin.Client.Unity.Workspace.Virtual.Component {

    public abstract class DigitalTwinComponentBase : IDigitalTwinEntityComponent
    {
        public IDigitalTwinEntity DigitalTwinEntity { get => throw new System.NotImplementedException(); init => throw new System.NotImplementedException(); }
        public string Id { get => throw new System.NotImplementedException(); init => throw new System.NotImplementedException(); }

        public bool HasConnection => throw new System.NotImplementedException();

        public T GetProperty<T>(string prop)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetPropertyAsync<T>(string prop)
        {
            throw new System.NotImplementedException();
        }

        public bool SetProperty<T>(string prop, T value)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SetPropertyAsync<T>(string prop, T value)
        {
            throw new System.NotImplementedException();
        }
    }

}