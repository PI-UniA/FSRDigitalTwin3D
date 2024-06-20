

using FSR.DigitalTwin.App.Common.Interfaces;

namespace FSR.DigitalTwin.App.Interfaces;

public interface IDataStreamingService 
{
    public bool CreateProperty(string name);
    public void SubscribeProperty(string name, IAsyncStreamWriter<byte[]> stream);
    public void UpdateValue(string name, byte[] value);
    public byte[] GetValue(string name);
    public bool HasProperty(string name);
    public bool RemoveProperty(string name);

}