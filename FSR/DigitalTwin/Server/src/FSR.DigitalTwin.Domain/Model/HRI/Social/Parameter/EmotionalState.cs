namespace FSR.DigitalTwin.Domain.Model.HRI.Social.Parameter;


public enum MediaPipe2025_FacialExpressionDimensions {
    Neutral, Angry, Disgusted, Fearful, Happy, Sad, Surprised
}

public class DimensionalEmotionMeasurement<T> : SocialParameter<Dictionary<T, float>> where T : Enum {
    
}

public class MediaPipe2025_FacialExpression : DimensionalEmotionMeasurement<MediaPipe2025_FacialExpressionDimensions> {
    
}