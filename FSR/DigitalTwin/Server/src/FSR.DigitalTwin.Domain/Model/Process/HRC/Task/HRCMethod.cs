using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC.Task;

public enum HRCMethodComplexTaskType {
    NONE,
    COLLECTION,
    CONJECTION,
    DISJUCTION
}

public class HRCMethodTask {
    public HRCMethodComplexTaskType NodeType { get; init; }
    public required OntologyResource Resource { get; init; }
    public List<OntologyResource> SubTasks { get; init; } = [];
}

public class HRCMethod {
    private readonly Dictionary<OntologyResource, HRCMethodTask> _nodes = [];
    public List<HRCMethodTask> Tasks { get; init; } = [];

    public HRCMethodTask GetMethodTask(OntologyResource task) {
        return _nodes[task];
    }

    public void AddMethodTask(HRCMethodTask task) {
        _nodes[task.Resource] = task;
        Tasks.Add(task);
    }
}