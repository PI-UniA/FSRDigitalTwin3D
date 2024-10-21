using FSR.DigitalTwin.Domain;

namespace FSR.DigitalTwin.App.Interfaces
{
    public interface IFaceExpressionService
    {
        Task HandleFaceExpressionDataAsync(FaceExpressionType expressionType, float probability);
        Task<Human> GetCurrentFaceExpressionAsync();
        Task FetchFaceExpressionDataAsync();
    }
}
