using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC.Agent;

public class Human : HRCAgent {
    public Human(OntologyResource agent) : base(agent) {}
    public List<OntologyResource> Embodyments { get; } = [];
}