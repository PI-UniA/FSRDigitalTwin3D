namespace FSR.DigitalTwin.Domain.Model.HRI.Social;

public class SocialExperienceRating : Entity {
    public enum ELabels {
        LIKE, DISLIKE, INDIFFERENT
    }
    public ELabels Value { init; get; }

}