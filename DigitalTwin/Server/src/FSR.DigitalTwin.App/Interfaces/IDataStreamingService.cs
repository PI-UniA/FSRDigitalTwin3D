

using FSR.DigitalTwin.App.Common.Interfaces;

namespace FSR.DigitalTwin.App.Interfaces;

public interface IDataStreamingService 
{
    public bool CreateProperty<T>(string name);
    public void SubscribeProperty<T>(string name, IAsyncStreamWriter<T> stream);
    public void UpdateValue<T>(string name, T value);
    public T GetValue<T>(string name);
    public bool HasProperty(string name);
    public bool RemoveProperty(string name);

}