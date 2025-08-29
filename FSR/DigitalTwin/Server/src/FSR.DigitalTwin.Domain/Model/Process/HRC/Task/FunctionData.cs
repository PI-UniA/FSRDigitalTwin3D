using VDS.RDF;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC.Task;

public record FunctionPropertyData
{
    public required UriNode Function { init; get; }
    public string? ProcedureName { init; get; }
    public string? ProcedureDescription { init; get; }
    public string? ProcedureId { init; get; }
    public long Duration { init; get; }
    public long DurationUncertainty { init; get; }
}

public record FunctionObjectData
{
    public required UriNode Function { init; get; }
    public HashSet<INode> Target { init; get; } = [];
    public HashSet<INode> StartLocation { init; get; } = [];
    public HashSet<INode> EndLocation { init; get; } = [];
    public HashSet<INode> Location { init; get; } = [];
}