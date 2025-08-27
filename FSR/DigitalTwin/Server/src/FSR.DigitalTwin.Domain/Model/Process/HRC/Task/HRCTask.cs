using VDS.RDF;
using VDS.RDF.Nodes;
using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC.Task;

public class HRCTask
{
    private readonly long _horizon;
    public OntologyResource Resource { get; }
    public required OntologyResource Type { get; init; }
    public OntologyResource? Target { set; get; }

    public string Name { set; get; }
    public string? Description { set; get; }
    public string? Goal { set; get; }
    public string? Start { set; get; }
    public string Agent { set; get; } = "any";
    public Tuple<long, long> Duration => new(
        Math.Max(1, AverageDuration - DurationUncertainty),
        Math.Min(AverageDuration + DurationUncertainty, _horizon)
    );
    public long AverageDuration { set; get; } = 1;
    public long DurationUncertainty { set; get; }
    public double SuccessRate { set; get; } = 0.99;

    public HRCTask(OntologyResource function, long horizon = long.MaxValue)
    {
        Name = function.Resource.NodeType == NodeType.Blank ? ((IBlankNode)function.Resource).InternalID
            : function.Label.Where(x => x.Language == "").First().ToString().Split("^^").First();
        Description = Name;
        Resource = function;
        DurationUncertainty = horizon;
        _horizon = horizon;
    }

    public override string ToString()
    {
        return "RobotFunction{" +
                "function=" + (Resource.Resource.NodeType == NodeType.Blank ? ((BlankNode) Resource.Resource).InternalID : ((UriNode) Resource.Resource).Uri) +
                '}';
    }
}