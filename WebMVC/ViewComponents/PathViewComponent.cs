using Microsoft.AspNetCore.Mvc;
using WebMVC.Interfaces;

namespace WebMVC.ViewComponents
{
    public class PathViewComponent : ViewComponent
    {
        private IWriterPathService _writerPathService { get; }

        public PathViewComponent(IWriterPathService writerPathService)
        {
            _writerPathService = writerPathService;
        }

        public IViewComponentResult Invoke()
        {
            return View("Path", _writerPathService.GetWritingPathForUser().Result);
        }
    }
}