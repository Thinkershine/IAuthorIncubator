using Microsoft.AspNetCore.Mvc;
using WebMVC.Interfaces;

namespace WebMVC.ViewComponents
{
    public class WritingPathViewComponent : ViewComponent
    {
        private IWriterPathService _writerPathService { get; }

        public WritingPathViewComponent(IWriterPathService writerPathService)
        {
            _writerPathService = writerPathService;
        }

        public IViewComponentResult Invoke(int pathID)
        {
            return View("WritingPath", _writerPathService.GetWritingPathForUser(pathID, "Thinkershine").Result);
        }
    }
}