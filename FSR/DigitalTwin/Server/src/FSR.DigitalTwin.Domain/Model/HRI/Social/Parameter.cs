namespace FSR.DigitalTwin.Domain.Model.HRI.Social;

public abstract class SocialParameter : Entity {
    public string? Name { init; get; }
}

public abstract class SocialParameter<T> : SocialParameter {
    public T? Value { get; set; }
}