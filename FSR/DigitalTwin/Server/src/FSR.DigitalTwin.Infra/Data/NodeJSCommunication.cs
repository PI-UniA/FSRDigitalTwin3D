using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FSR.DigitalTwin.App.Common.Interfaces;
using FSR.DigitalTwin.Domain;

namespace FSR.DigitalTwin.Infra.Data
{
    public class NodeJsCommunicationService : INodeJsCommunicationService
    {
        private readonly HttpClient _httpClient;

        public NodeJsCommunicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Check if Node.js server is active
        public async Task<bool> CheckNodeJsServerStatusAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5000/status");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // Receive pose data from Node.js app
        public async Task<(List<PoseLandmark> Pose, List<WorldPoseLandmark> WorldPose)> GetPoseDataAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5000/pose");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var poseData = JsonSerializer.Deserialize<Dictionary<string, List<PoseLandmark>>>(content);
            var worldPoseData = JsonSerializer.Deserialize<Dictionary<string, List<WorldPoseLandmark>>>(content);

            return (poseData?["Pose"] ?? new List<PoseLandmark>(), worldPoseData?["WorldPose"] ?? new List<WorldPoseLandmark>());
        }

        // Receive face expression data from Node.js app
        public async Task<(FaceExpressionType ExpressionType, float Probability)> GetFaceExpressionDataAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5000/emotion");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var expressionData = JsonSerializer.Deserialize<(FaceExpressionType ExpressionType, float Probability)>(content);
            
            return expressionData;
        }
    }
}
