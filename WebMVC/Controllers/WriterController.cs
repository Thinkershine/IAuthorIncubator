using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Writer/GetWriter")]
        public IActionResult GetWriter()
        {
            return ViewComponent("WriterProfile");
        }
    }
}