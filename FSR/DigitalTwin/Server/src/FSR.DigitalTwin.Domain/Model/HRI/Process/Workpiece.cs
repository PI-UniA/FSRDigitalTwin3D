namespace FSR.DigitalTwin.Domain.Model.HRI.Process;

public class Workpiece : Entity {
    public string? Name { init; get; }
    public string? Description { init; get; }
}

public class CompositeWorkpiece : Workpiece {
    public List<Workpiece> Constituents { init; get; } = [];
}