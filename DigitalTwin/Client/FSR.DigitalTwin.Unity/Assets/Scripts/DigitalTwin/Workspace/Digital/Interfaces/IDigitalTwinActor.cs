using System.Threading.Tasks;

namespace FSR.DigitalTwin.Unity.Workspace.Digital.Interfaces {

public interface IDigitalTwinActor
{
    public DigitalWorkspace DigitalWorkspace { get; }

    public Task<int> PullDataAndApplyAsync();
    int PullDataAndApply();

    public Task<int> PushDataAsync();
    public int PushData();

}

} // END namespace FSR.DigitalTwin.Unity.Workspace.Digital.Interfaces