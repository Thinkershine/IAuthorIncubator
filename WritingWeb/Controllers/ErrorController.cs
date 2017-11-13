using Microsoft.AspNetCore.Mvc;
using WritingWeb.Helpers;

namespace WritingWeb.Controllers
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