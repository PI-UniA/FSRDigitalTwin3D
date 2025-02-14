namespace FSR.DigitalTwin.Domain.Model.HRI.Social;

public abstract class SocialAttribute : Entity {
    public List<SocialParameter> Parameters { get; init; } = [];
}