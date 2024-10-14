using Microsoft.AspNetCore.Mvc;

namespace FaceApiApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DetectionsController : ControllerBase
{
    private static List<Detection> detections = new List<Detection>
    {
        new Detection { Id = 1, ImageBase64 = "image1", Gender = "male", Age = 25 },
        new Detection { Id = 2, ImageBase64 = "image2", Gender = "female", Age = 30 }
    };

    // GET: api/detections
    [HttpGet]
    public ActionResult<List<Detection>> Get()
    {
        return Ok(detections);
    }
}
