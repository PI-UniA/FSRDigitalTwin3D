using System.Collections;
using FSR.DigitalTwin.App.Common.Interfaces;
using FSR.DigitalTwin.App.Interfaces;

namespace FSR.DigitalTwin.App.Services;

public class DataStreamingService : IDataStreamingService
{
    private readonly Hashtable _streamedValue = [];

    public bool CreateValue(string name)
    {
        if (_streamedValue.ContainsKey(name)) {
            return false;
        }
        _streamedValue[name] = new List<IAsyncStreamWriter<byte[]>>();
        return true;
    }

    public bool RemoveValue(string name)
    {
        if (!_streamedValue.ContainsKey(name)) {
            return false;
        }
        _streamedValue.Remove(name);
        return true;
    }

    public void SubscribeValue(string name, IAsyncStreamWriter<byte[]> stream)
    {
        (_streamedValue[name] as List<IAsyncStreamWriter<byte[]>>)?.Add(stream);
    }

    public void UpdateValue(string name, byte[] value)
    {
        List<IAsyncStreamWriter<byte[]>> writers = (_streamedValue[name] as List<IAsyncStreamWriter<byte[]>>) ?? [];
        foreach (var writer in writers) {
            writer.WriteAsync(value);
        }
    }
}