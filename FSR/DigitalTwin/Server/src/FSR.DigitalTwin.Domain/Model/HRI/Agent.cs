using FSR.DigitalTwin.Domain.Model.HRI.Process;

namespace FSR.DigitalTwin.Domain.Model.HRI;

public class Agent : Entity {
    public string? Name { set; get; }
    public List<ProcessTask> AssignableTasks { get; } = [];
}