

using FSR.DigitalTwin.App.Common.Interfaces;

namespace FSR.DigitalTwin.App.Interfaces;

public interface IDataStreamingService 
{
    public bool CreateValue(string name);
    public void SubscribeValue(string name, IAsyncStreamWriter<byte[]> stream);
    public void UpdateValue(string name, byte[] value);
    public bool RemoveValue(string name);

}