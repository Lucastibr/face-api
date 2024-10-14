using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace FaceApiApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DetectionsController : ControllerBase
{
    private readonly DetectionService _detectionService;

    public DetectionsController(DetectionService detectionService)
    {
        _detectionService = detectionService;
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

        return Ok(detection);
    }

    // GET: api/detections
    [HttpGet]
    public async Task<List<Detection>> GetDetections()
    {
        return await _detectionService.GetDetectionsAsync();
    }
}
