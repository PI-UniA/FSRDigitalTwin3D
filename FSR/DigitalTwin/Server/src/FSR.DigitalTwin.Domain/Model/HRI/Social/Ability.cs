using FSR.DigitalTwin.Domain.Model.HRI.Process;

namespace FSR.DigitalTwin.Domain.Model.HRI.Social;

public abstract class SocialAbility : Entity {
    public string? Name { init; get; }
}

// A social ability that represents the ability to conduct a cooperative task with peers working towards the same goal
public abstract class CooperativeSocialAbility : SocialAbility {
    public required SocialAgent Owner { init; get; }
    public List<SocialAgent> Peers { init; get; } = [];
    public List<ProcessTask> CooperativeTasks { init; get; } = [];
    public required Goal Goal { init; get; }
}

// A social ability that takes the emotional state of a peer into account
public abstract class ExpressedEmpathySocialAbility : SocialAbility {
    public required SocialAgent Peer { init; get; }

    // TODO The Emotional state of a specific Agent as a Social Attribute.
    // public EmotionalState EmotionalState { init; get; }

}