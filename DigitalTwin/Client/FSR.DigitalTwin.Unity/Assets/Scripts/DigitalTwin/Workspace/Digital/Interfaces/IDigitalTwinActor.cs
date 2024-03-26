using System.Threading.Tasks;

namespace FSR.DigitalTwin.Unity.Workspace.Digital.Interfaces {

public interface IDigitalTwinActor
{
    public DigitalWorkspace DigitalWorkspace { get; }

    public Task<int> OnSynchronizeDataAsync();
    public int OnSynchronizeData();

    public Task<int> OnPushDataAsync();
    public int OnPushData();

}

} // END namespace FSR.DigitalTwin.Unity.Workspace.Digital.Interfaces