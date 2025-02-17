using FSR.DigitalTwin.Domain.Model.HRI.Social.Attribute;

namespace FSR.DigitalTwin.Domain.Model.HRI.Social.Parameter;

public class EmotionalState<T> : SocialParameter<Dictionary<T, float>> where T : Enum {

}

public class MediaPipe2025_FacialExpression : EmotionalState<MediaPipe2025_FacialExpressionDimensions> {

}