using Microsoft.AspNetCore.Mvc;
using WebMVC.Interfaces;

namespace WebMVC.ViewComponents
{
    public class WritingDayHeaderViewComponent : ViewComponent
    {
        private IWriterPathService _writerPathService;

        public WritingDayHeaderViewComponent(IWriterPathService writerPathSerivce)
        {
            _writerPathService = writerPathSerivce;
        }

        public IViewComponentResult Invoke(int dayId)
        {
            return View("WritingDayHeader", _writerPathService.GetPathDayHeader(dayId).Result);
        }
    }
}