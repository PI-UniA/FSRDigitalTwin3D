using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC.Agent;

public class Robot : HRCAgent {
    public Robot(OntologyResource agent) : base(agent) {}
    public List<OntologyResource> Embodyments { get; } = [];
}