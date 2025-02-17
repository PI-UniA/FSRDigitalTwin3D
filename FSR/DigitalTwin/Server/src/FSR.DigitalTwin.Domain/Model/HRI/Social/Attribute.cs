namespace FSR.DigitalTwin.Domain.Model.HRI.Social;

public class SocialAttribute : Entity {
    public List<SocialParameter> Parameters { get; init; } = [];
}