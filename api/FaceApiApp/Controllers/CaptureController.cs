using Microsoft.AspNetCore.Mvc;

namespace FaceApiApp.Controllers
{
    public class CaptureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
