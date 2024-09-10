namespace FSR.DigitalTwin.App.Interfaces.Services;

public interface IDigitalWorkspaceService {
    string DigitalTwinVersion { get; }
    Task SendClientNotification();

    // Task GetInfrastructure()
    // Task AddROSConnectionToAsset()
    // Task AddMQTTConnectionToAsset()
    // We'll see what we need...
}