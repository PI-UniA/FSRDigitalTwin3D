using System.Collections;
using FSR.DigitalTwin.App.Common.Interfaces;
using FSR.DigitalTwin.App.Interfaces;

namespace FSR.DigitalTwin.App.Services;

public class DataStreamingService : IDataStreamingService
{
    private readonly Hashtable _streams = [];
    private readonly Hashtable _values = [];

    public bool CreateProperty<T>(string name)
    {
        if (_values.ContainsKey(name)) {
            return false;
        }
        _streams[name] = new List<IAsyncStreamWriter<T>>();
        _values[name] = null;
        return true;
    }

    public T GetValue<T>(string name)
    {
        return (T)(_values[name] ?? throw new NullReferenceException());
    }

    public bool HasProperty(string name)
    {
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

    public void SubscribeProperty<T>(string name, IAsyncStreamWriter<T> stream)
    {
        (_streams[name] as List<IAsyncStreamWriter<T>>)?.Add(stream);
    }

    public void UpdateValue<T>(string name, T value)
    {
        _values[name] = value;
        List<IAsyncStreamWriter<T>> writers = (_streams[name] as List<IAsyncStreamWriter<T>>) ?? [];
        foreach (var writer in writers) {
            writer.WriteAsync(value);
        }
    }
}