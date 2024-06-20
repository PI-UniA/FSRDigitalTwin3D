using System.Collections;
using FSR.DigitalTwin.App.Common.Interfaces;
using FSR.DigitalTwin.App.Interfaces;

namespace FSR.DigitalTwin.App.Services;

public class DataStreamingService : IDataStreamingService
{
    private readonly Hashtable _streams = [];
    private readonly Hashtable _values = [];

    public bool CreateProperty(string name)
    {
        if (_values.ContainsKey(name)) {
            return false;
        }
        _streams[name] = new List<IAsyncStreamWriter<byte[]>>();
        _values[name] = null;
        return true;
    }

    public byte[] GetValue(string name)
    {
        return _values[name] as byte[] ?? [];
    }

    public bool HasProperty(string name) {
        return _values.ContainsKey(name);
    }

    public bool RemoveProperty(string name)
    {
        if (!_values.ContainsKey(name)) {
            return false;
        }
        _streams.Remove(name);
        _values.Remove(name);
        return true;
    }

    public void SubscribeProperty(string name, IAsyncStreamWriter<byte[]> stream)
    {
        (_streams[name] as List<IAsyncStreamWriter<byte[]>>)?.Add(stream);
    }

    public void UpdateValue(string name, byte[] value)
    {
        _values[name] = value;
        List<IAsyncStreamWriter<byte[]>> writers = (_streams[name] as List<IAsyncStreamWriter<byte[]>>) ?? [];
        foreach (var writer in writers) {
            writer.WriteAsync(value);
        }
    }
}