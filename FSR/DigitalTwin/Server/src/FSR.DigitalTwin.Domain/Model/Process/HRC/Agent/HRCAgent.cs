using VDS.RDF;
using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC.Agent;

public abstract class HRCAgent {
    public string Name { set; get; }
    public required OntologyResource Resource { init; get; }

    public HRCAgent(OntologyResource agent) {
        Name = agent.Resource.NodeType == NodeType.Blank ? ((IBlankNode)agent.Resource).InternalID
            : agent.Label.Where(x => x.Language == "de").Any() ? agent.Label.Where(x => x.Language == "de").First().Value
            : agent.Label.Any() ? agent.Label.First().Value
            : "";
    }
}