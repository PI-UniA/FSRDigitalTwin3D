using FSR.DigitalTwin.Domain.Model.Process.HRC.Task;
using VDS.RDF;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC;

public class HRCModel {
    private readonly long _horizon;
    private readonly Dictionary<INode, HRCTask> _tasks = [];
    private readonly Dictionary<INode, HRCTask> _robotTasks = [];
    private readonly Dictionary<INode, HRCTask> _humanTasks = [];

    public IList<HRCTask> Tasks => [.. _tasks.Values];
    public IList<HRCTask> RobotTasks => [.. _robotTasks.Values];
    public IList<HRCTask> HumanTasks => [.. _humanTasks.Values];

    public HRCModel(long horizon)
    {
        _horizon = horizon;
    }

    public HRCTask CreateRobotTask(INode function, INode type) {
        HRCTask task = new(function, type, _horizon);
        _tasks.Add(task.Resource, task);
        _robotTasks.Add(task.Resource, task);
        task.Agent = "robot";
        return task;
    }

    public HRCTask CreateHumanTask(INode function, INode type) {
        HRCTask task = new(function, type, _horizon);
        _tasks.Add(task.Resource, task);
        _humanTasks.Add(task.Resource, task);
        task.Agent = "human";
        return task;
    }

    public HRCTask CreateHRCTask(INode function, INode type) {
        HRCTask task = new(function, type, _horizon);
        _tasks.Add(task.Resource, task);
        return task;
    }
}