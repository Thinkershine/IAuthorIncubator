using Microsoft.AspNetCore.Mvc;
using WebMVC.Helpers;

namespace WebMVC.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error/404")]
        public IActionResult Error404()
        {
            return new NotFoundViewResult("_404Error");
        }
    }
}