using AngleSharp.Dom;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC.Task;

public record FunctionData
{
    public required INode Function { init; get; }
    public string? ProcedureName { init; get; }
    public string? ProcedureDescription { init; get; }
    public string? ProcedureId { init; get; }
    public long Duration { init; get; }
    public long DurationUncertainty { init; get; }
}

public record FunctionObjectData
{
    public required INode Function { init; get; }
    public INode? Target { init; get; }
    public INode? StartLocation { init; get; }
    public INode? EndLocation { init; get; }
    public INode? Location { init; get; }
}