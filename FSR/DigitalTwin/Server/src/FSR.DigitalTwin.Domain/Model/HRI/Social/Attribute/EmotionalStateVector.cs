using FSR.DigitalTwin.Domain.Model.HRI.Social.Parameter;

namespace FSR.DigitalTwin.Domain.Model.HRI.Social.Attribute;

/// <summary>
/// Represents an agent's emotional state described by a measured emotion vector (see the parameter)
/// </summary>
public class EmotionalStateVector : SocialAttribute {
    public required SocialAgent Agent { init; get; }
}

/// <summary>
/// Represents an agent's emotional state described by a measured emotion vector (see the parameter)
/// </summary>
/// <typeparam name="T"> An Enum representing the labels of human emotion </typeparam>
public class EmotionalStateVector<T> : EmotionalStateVector where T : Enum {
    public EmotionalState<T> EmotionalState { get; }
    public EmotionalStateVector(EmotionalState<T> emotionalState)  {
        EmotionalState = emotionalState;
        if (!Parameters.Contains(emotionalState)) {
            Parameters.Add(emotionalState);
        }
    }
}

public enum MediaPipe2025_FacialExpressionDimensions {
    Neutral, Angry, Disgusted, Fearful, Happy, Sad, Surprised
}

public class MediaPipe2025_FacialExpressionVector : EmotionalState<MediaPipe2025_FacialExpressionDimensions> {
    
}