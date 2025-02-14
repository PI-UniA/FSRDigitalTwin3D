using FSR.DigitalTwin.Domain.Model.HRI.Process;
using FSR.DigitalTwin.Domain.Model.HRI.Social;

namespace FSR.DigitalTwin.Domain.Model.HRI;

// Describes a use case containing its agents, its processes, its social entities and generally all modelled entities
public class Scenario : Entity {

    public List<Agent> Agents { init; get; } = [];
    public List<Goal> Goals { init; get; } = [];
    public List<Plan> Plans { init; get; } = [];

}

public class SocialScenario : Scenario {

    public List<SocialAgent> SocialAgents { init; get; } = [];
    public List<SocialAttribute> SocialAttributes { init; get; } = [];
    public List<SocialParameter> SocialParameters { init; get; } = [];

}