using FSR.DigitalTwin.Domain.Model.HRI.Social.Parameter;

namespace FSR.DigitalTwin.Domain.Model.HRI.Social.Attribute;

public class EmotionVector<T> : SocialAttribute where T : Enum  {
    public required SocialAgent Agent { init; get; }
    public List<DimensionalEmotionMeasurement<T>> EmotionMeasurements { get; } = [];

    public EmotionVector(List<DimensionalEmotionMeasurement<T>>? emotionMeasurements = null)  {
        EmotionMeasurements = [.. emotionMeasurements ?? []];
        Parameters = [.. emotionMeasurements ?? []];
    }
}