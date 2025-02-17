using FSR.DigitalTwin.Domain.Model.HRI.Process;
using FSR.DigitalTwin.Domain.Model.HRI.Social.Attribute;

namespace FSR.DigitalTwin.Domain.Model.HRI.Social;

public abstract class SocialAbility : Entity {
    public string? Name { init; get; }
}

/// <summary>
/// A social ability that represents the ability to conduct a cooperative task with peers working towards the same goal
/// </summary>
public class CooperativeSocialAbility : SocialAbility {
    public required SocialAgent Owner { init; get; }
    public List<SocialAgent> Peers { init; get; } = [];
    public List<ProcessTask> CooperativeTasks { init; get; } = [];
    public required Goal Goal { init; get; }
}

/// <summary>
/// A social ability that takes the emotional state of a peer into account
/// </summary>
public class ExpressedEmpathySocialAbility : SocialAbility {
    public required EmotionalStateVector EmotionalState { init; get; }
}