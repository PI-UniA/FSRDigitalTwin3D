namespace FSR.DigitalTwin.Domain.Model.HRI.Social;

public class SocialBehaviorModel : Entity {
    public required SocialAgent SocialAgent { init; get; }
    public List<SocialAbility> Abilities { init; get; } = [];

}