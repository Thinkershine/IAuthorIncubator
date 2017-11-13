using Microsoft.AspNetCore.Mvc;
using WritingWeb.Interfaces;

namespace WritingWeb.ViewComponents
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