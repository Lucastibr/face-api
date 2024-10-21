using FaceApiApp.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;

namespace FaceApiApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DetectionsController : ControllerBase
{
    private readonly DetectionService _detectionService;
    private readonly IHubContext<DetectionHub> _hubContext;

    public DetectionsController(DetectionService detectionService, IHubContext<DetectionHub> hubContext)
    {
        _detectionService = detectionService;
        _hubContext = hubContext;
    }

    // POST: api/detections
    [HttpPost]
    public async Task<IActionResult> CreateDetection([FromBody] Detection detection)
    {
        if (detection == null)
        {
            return BadRequest();
        }

        // Gera um novo Id se o Id não for fornecido
        if (string.IsNullOrEmpty(detection.Id))
        {
            detection.Id = ObjectId.GenerateNewId().ToString(); // Gera um novo ObjectId
        }


        detection.Date = DateTime.Now;  // Adiciona a data da detecção
        await _detectionService.CreateDetectionAsync(detection);

        await _hubContext.Clients.All.SendAsync("ReceiveDetectionUpdate", detection.Gender, detection.Age, detection.ImageBase64);

        return Ok(detection);
    }

    // GET: api/detections
    [HttpGet]
    public async Task<List<Detection>> GetDetections()
    {
        return await _detectionService.GetDetectionsAsync();
    }
}
