namespace FSR.DigitalTwin.Domain;
public class PoseLandmark
{
    public float X { get; set; } // Real-world x coordinate
    public float Y { get; set; } // Real-world y coordinate
    public float Z { get; set; } // Real-world z coordinate
    public float? Visibility { get; set; } // Visibility score
}