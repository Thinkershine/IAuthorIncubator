using Microsoft.AspNetCore.Mvc;
using WebMVC.Interfaces;

namespace WebMVC.ViewComponents
{
    public class WorkingDayViewComponent : ViewComponent
    {
        private IWriterPathService _writerPathService;

        public WorkingDayViewComponent(IWriterPathService writerPathSerivce)
        {
            _writerPathService = writerPathSerivce;
        }

        public IViewComponentResult Invoke(int[] dayIds)
        {
            int pathId = dayIds[0];
            int dayId = dayIds[1];
            return View("WorkingDay", _writerPathService.GetPathDayBody(pathId, dayId, "Thinkershine").Result);
        }
    }
}