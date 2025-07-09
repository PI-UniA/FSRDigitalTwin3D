using VDS.RDF.Ontology;

namespace FSR.DigitalTwin.Domain.Model.Process.HRC.Parameter;

// SOHO + DUL
// parametrizes :: (Parameter) -> (Region)
// hasParameter :: (Concept) -> (Parameter)
// hasRegion :: (Entity) -> (Region)
// classifies :: (Concept) -> (Entity) Eine Klassifizierung!

// Define all types of possible parameter types here...
public enum ParameterType {
    UNTYPED,

    // FORSocialRobots
    // Extrinsic parameters
    SOCIAL_PARAM_TEMPERATURE,
    SOCIAL_PARAM_NOISE,
    SOCIAL_PARAM_LIGHTING,

    // Intrinsic parameters
    SOCIAL_PARAM_EMOTION_STATE,
    SOCIAL_PARAM_HEAD_GAZE,
    SOCIAL_PARAM_BODY_GESTURE

}

public class Parameter {
    public required ParameterType Type { get; init; }
    public List<OntologyResource> Regions { get; init; } = [];
}