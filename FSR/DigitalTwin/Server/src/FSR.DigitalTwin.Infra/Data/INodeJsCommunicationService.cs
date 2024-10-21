using FSR.DigitalTwin.Domain;

namespace FSR.DigitalTwin.App.Common.Interfaces
{
    public interface INodeJsCommunicationService
    {
        Task<bool> CheckNodeJsServerStatusAsync();
        Task<(List<PoseLandmark> Pose, List<WorldPoseLandmark> WorldPose)> GetPoseDataAsync();
        Task<(FaceExpressionType ExpressionType, float Probability)> GetFaceExpressionDataAsync();
    }
}
    