

namespace FSR.DigitalTwin.App.Interfaces.Services;

public interface IDigitalTwinClientConnectionService {
    bool AddBidirectionalConnectionStream(string id, StreamReader reader, StreamWriter writer);
    bool RemoveConnection(string id);
    Tuple<StreamReader, StreamWriter>[] GetAllConnections();
    Tuple<StreamReader, StreamWriter> GetConnectionById(string id);
    Tuple<StreamReader, StreamWriter>? TryGetConnectionById(string id);
}