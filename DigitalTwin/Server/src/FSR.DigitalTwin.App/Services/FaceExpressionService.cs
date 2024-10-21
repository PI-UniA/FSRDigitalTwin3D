using FSR.DigitalTwin.App.Common.Interfaces;
using FSR.DigitalTwin.App.Interfaces;
using FSR.DigitalTwin.Domain;

namespace FSR.DigitalTwin.App.Services
{
    public class FaceExpressionService : IFaceExpressionService
    {
        private readonly INodeJsCommunicationService _nodeJsCommunicationService;
        private Human _currentFaceExpression = new Human();

        public FaceExpressionService(INodeJsCommunicationService nodeJsCommunicationService)
        {
            _nodeJsCommunicationService = nodeJsCommunicationService;
        }

        // Handle face expression data received from Node.js app
        public async Task HandleFaceExpressionDataAsync(FaceExpressionType expressionType, float probability)
        {
            _currentFaceExpression.FaceExpression = expressionType;
            _currentFaceExpression.FaceExpressionProbability = probability;
            _currentFaceExpression.Timestamp = DateTime.UtcNow;

            await LogFaceExpressionDataAsync(expressionType, probability);
        }

        // Log face expression data to console
        private async Task LogFaceExpressionDataAsync(FaceExpressionType expressionType, float probability)
        {
            await Console.Out.WriteLineAsync($"Expression: {expressionType}, Probability: {probability}, Timestamp: {_currentFaceExpression.Timestamp}");
        }

        // Get current face expression data
        public async Task<Human> GetCurrentFaceExpressionAsync()
        {
            return await Task.FromResult(_currentFaceExpression);
        }

        // Fetch face expression data from Node.js app
        public async Task FetchFaceExpressionDataAsync()
        {
            var (expressionType, probability) = await _nodeJsCommunicationService.GetFaceExpressionDataAsync();
            await HandleFaceExpressionDataAsync(expressionType, probability);
        }
    }
}
