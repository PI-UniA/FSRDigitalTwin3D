namespace FSR.DigitalTwin.Domain.Model.HRI.Process;

public abstract class ProcessTask : Entity {
    public string? ProcedureName { init; get; }
}

public class CompositeProcessTask : ProcessTask {
    public enum ECompositionType {
        Sequence, Alternatives
    }
    public ECompositionType Type { init; get; }
    public List<ProcessTask> Tasks { init; get; } = [];
}

public class Function : ProcessTask {
    public Agent? AssignedTo { get; set; }
    public float? Duration { set; get; }
    public float? DurationUncertainty { set; get; }
    public Entity? Goal { set; get; }
}