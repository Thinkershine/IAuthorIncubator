using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            return View("Default", _writerPathService.GetPathDayHeader(pathId, dayId, "Thinkershine").Result);
        }
    }
}