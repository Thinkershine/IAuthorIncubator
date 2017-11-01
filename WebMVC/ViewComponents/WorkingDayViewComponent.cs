using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.ViewComponents
{
    public class WorkingDayViewComponent : ViewComponent
    {
        private IWriterPathService _writerPathService;

        public WorkingDayViewComponent(IWriterPathService writerPathSerivce)
        {
            _writerPathService = writerPathSerivce;
        }

        public IViewComponentResult Invoke(int[] dataId)
        {
            int pathId = dataId[0];
            int dayId = dataId[1];
            return View("Default", _writerPathService.GetPathDayBody(pathId, dayId, "Thinkershine").Result);
        }
    }
}