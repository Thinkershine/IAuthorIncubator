using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.ViewComponents
{
    public class WritingDayHeaderViewComponent : ViewComponent
    {
        private IWriterPathService _writerPathService;

        public WritingDayHeaderViewComponent(IWriterPathService writerPathSerivce)
        {
            _writerPathService = writerPathSerivce;
        }

        public IViewComponentResult Invoke(int pathId, int dayId)
        {
            // Todo: Create it Async
            return View("WritingDayHeaderView", _writerPathService.GetPathDayHeader(pathId, dayId, "Thinkershine").Result);
        }
    }
}