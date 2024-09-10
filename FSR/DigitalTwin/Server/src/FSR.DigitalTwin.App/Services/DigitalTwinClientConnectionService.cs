using FSR.DigitalTwin.App.Interfaces.Services;
using ConnectonPair = System.Tuple<System.IO.StreamReader, System.IO.StreamWriter>;

namespace FSR.DigitalTwin.App.Services;

public class DigitalTwinClientConnectionService : IDigitalTwinClientConnectionService
{
    private readonly Dictionary<string, ConnectonPair> _connectionState = [];

    public bool AddBidirectionalConnectionStream(string id, StreamReader reader, StreamWriter writer)
    {
        if (_connectionState.ContainsKey(id)) {
            return false;
        }
        _connectionState.Add(id, new ConnectonPair(reader, writer));
        return true;
    }

    public ConnectonPair[] GetAllConnections()
    {
        return [.. _connectionState.Values];
    }

    public ConnectonPair GetConnectionById(string id)
    {
        return _connectionState[id];
    }

    public ConnectonPair? TryGetConnectionById(string id){
        _connectionState.TryGetValue(id, out ConnectonPair? value);
        return value;
    }

    public bool RemoveConnection(string id)
    {
        return _connectionState.Remove(id);
    }
}