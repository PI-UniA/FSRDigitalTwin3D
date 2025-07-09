using FSR.DigitalTwin.Domain.Model.Process.HRC.Task;
using VDS.RDF;
using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC;

public class HRCModel {
    private readonly long _horizon;
    private readonly Dictionary<OntologyResource, HRCTask> _tasks = [];
    private readonly Dictionary<OntologyResource, HRCTask> _robotTasks = [];
    private readonly Dictionary<OntologyResource, HRCTask> _humanTasks = [];

    public IList<HRCTask> Tasks => [.. _tasks.Values];
    public IList<HRCTask> RobotTasks => [.. _robotTasks.Values];
    public IList<HRCTask> HumanTasks => [.. _humanTasks.Values];

    public HRCModel(long horizon) {
        _horizon = horizon;
    }

    public HRCTask CreateRobotTask(OntologyResource function, OntologyResource type) {
        HRCTask task = new(function, _horizon) { Type = type };
        _tasks.Add(task.Resource, task);
        _robotTasks.Add(task.Resource, task);
        task.Agent = "robot";
        return task;
    }

    public HRCTask CreateHumanTask(OntologyResource function, OntologyResource type) {
        HRCTask task = new(function, _horizon) { Type = type };
        _tasks.Add(task.Resource, task);
        _humanTasks.Add(task.Resource, task);
        task.Agent = "human";
        return task;
    }

    public HRCTask CreateHRCTask(OntologyResource function, OntologyResource type) {
        HRCTask task = new(function, _horizon) { Type = type };
        _tasks.Add(task.Resource, task);
        return task;
    }
}