using Microsoft.AspNetCore.Mvc;
using FSR.DigitalTwin.App.Interfaces;
using FSR.DigitalTwin.Domain;

namespace FSR.DigitalTwin.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaceExpressionController : ControllerBase
    {
        private readonly IFaceExpressionService _faceExpressionService;

        public FaceExpressionController(IFaceExpressionService faceExpressionService)
        {
            _faceExpressionService = faceExpressionService;
        }

        [HttpPost("handle-face-data")]
        public async Task<IActionResult> HandleFaceDataAsync([FromBody] FaceExpressionRequest request)
        {
             Console.WriteLine($"Received face expression data: {request.ExpressionType}, Probability: {request.Probability}");

            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }

            await _faceExpressionService.HandleFaceExpressionDataAsync(request.ExpressionType, request.Probability);
            return Ok("Face expression data received and processed.");
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentFaceExpressionAsync()
        {
            var currentExpression = await _faceExpressionService.GetCurrentFaceExpressionAsync();
            return Ok(currentExpression);
        }
    }

    // DTO for face expression request
    public class FaceExpressionRequest
    {
        public FaceExpressionType ExpressionType { get; set; }
        public float Probability { get; set; }
    }
}
