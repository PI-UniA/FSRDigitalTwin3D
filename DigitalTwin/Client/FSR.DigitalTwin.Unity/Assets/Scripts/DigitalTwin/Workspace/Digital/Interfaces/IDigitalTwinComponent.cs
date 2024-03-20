using System.Threading.Tasks;
using FSR.DigitalTwin.Unity.Workspace.Digital;

public interface IDigitalTwinComponent
{
    public DigitalWorkspace DigitalWorkspace { get; }

    public Task<int> PullDataAndApplyAsync();
    int PullDataAndApply();

    public Task<int> PushDataAsync();
    public int PushData();

}
