using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC.Agent;

public class Cobot : HRCAgent {
    public Cobot(OntologyResource agent) : base(agent) {}
    public List<OntologyResource> Embodyments { get; } = [];
}