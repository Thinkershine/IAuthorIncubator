using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("WritingPath/{pathID?}")]
        public IActionResult GetWritingPath(int pathID)
        {
            // Todo : If no writing path ID return last_used_path

            return ViewComponent("WritingPath");
        }
    }
}