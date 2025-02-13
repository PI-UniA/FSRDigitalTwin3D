namespace FSR.DigitalTwin.Domain.Model.HRI.Social;

public class SocialAgent : Agent {
    List<SocialAbility> SocialAbilities { init; get; } = [];
}