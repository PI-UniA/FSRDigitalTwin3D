namespace FSR.DigitalTwin.Domain.Model.HRI.Process;

public class Plan : Entity {
    public string? Description { set; get; }
    public required Goal Goal { init; get; }
    public List<ProcessTask> DescribedBy { init; get; } = [];

}