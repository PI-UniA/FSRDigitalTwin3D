namespace FSR.DigitalTwin.Domain;

public class Human
{
    public DateTime Timestamp { get; set; } // Time when the data was captured
    public FaceExpressionType FaceExpression { get; set; }
    public float FaceExpressionProbability { get; set; }
    public List<PoseLandmark> PoseLandmarks { get; set; } = new List<PoseLandmark>();
    public List<WorldPoseLandmark> WorldPoseLandmarks { get; set; } = new List<WorldPoseLandmark>();

    public Human()
    {
        Timestamp = DateTime.UtcNow; // Initialize with the current time
    }
}
