namespace FSR.DigitalTwin.Domain.Model.HRI.Process;

public class Goal : Entity {
    public static readonly Goal Default = new() { Id = "default-goal", Description = "The default goal", Methods = [] };
    public string? Description { set; get; }
    public List<ProcessTask> Methods { init; get; } = [];
}