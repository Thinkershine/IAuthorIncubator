using Microsoft.AspNetCore.Mvc;

namespace WritingWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("WritingPath")]
        public IActionResult GetWritingPath()
        {
            // Todo : If no writing path ID return last_used_path

            return ViewComponent("Path");
        }

        [Route("WritingPath/{dayID?}")]
        public IActionResult GetHiddenQuote(int dayID)
        {
            return ViewComponent("HiddenQuote", dayID);
        }
    }
}