using FSR.DigitalTwin.Domain.Model.HRI.Process;

namespace FSR.DigitalTwin.Domain.Model.HRI.Social;

public class SocialFunction : Function {
    public List<SocialAbility> Impacted { get; init; } = [];
}