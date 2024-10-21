// using FSR.DigitalTwin.App.Interfaces;
// using FSR.DigitalTwin.Domain;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace FSR.DigitalTwin.API.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class PoseTrackingController : ControllerBase
//     {
//         private readonly IPoseTrackingService _poseTrackingService;

//         public PoseTrackingController(IPoseTrackingService poseTrackingService)
//         {
//             _poseTrackingService = poseTrackingService;
//         }

//         [HttpGet("current-pose")]
//         public async Task<IActionResult> GetCurrentPoseAsync()
//         {
//             var pose = await _poseTrackingService.GetCurrentPoseAsync();
//             return Ok(pose);
//         }

//         [HttpPost("handle-pose-data")]
//         public async Task<IActionResult> HandlePoseData([FromBody] PoseDataDto poseData)
//         {
//             if (poseData == null)
//             {
//                 return BadRequest("Pose data is null.");
//             }

//             if (poseData.PoseLandmarks == null || poseData.WorldPoseLandmarks == null)
//             {
//                 return BadRequest("PoseLandmarks and WorldPoseLandmarks are required.");
//             }

//             // Log the received data for debugging
//             Console.WriteLine($"Received {poseData.PoseLandmarks.Count} pose landmarks and {poseData.WorldPoseLandmarks.Count} world pose landmarks.");

//             await _poseTrackingService.HandlePoseDataAsync(poseData.PoseLandmarks, poseData.WorldPoseLandmarks);

//             return Ok();
//         }
//     }

//     // DTO for receiving pose data
//     public class PoseDataDto
//     {
//         public List<PoseLandmark> PoseLandmarks { get; set; }
//         public List<WorldPoseLandmark> WorldPoseLandmarks { get; set; }
//     }
// }
