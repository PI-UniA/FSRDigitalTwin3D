

namespace FSR.DigitalTwin.App.Interfaces.Services;

public interface IDigitalTwinClientConnectionService {
    bool AddBidirectionalConnectionStream(string id, object reader, object writer);
    bool RemoveConnection(string id);
    Tuple<object, object>[] GetAllConnections();
    Tuple<object, object> GetConnectionById(string id);
    Tuple<object, object>? TryGetConnectionById(string id);
}