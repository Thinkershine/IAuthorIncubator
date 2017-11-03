using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.ViewComponents
{
    public class HiddenQuoteViewComponent : ViewComponent
    {
        private IWriterPathService _writerPathService { get; }

        public HiddenQuoteViewComponent(IWriterPathService writerPathService)
        {
            _writerPathService = writerPathService;
        }

        public IViewComponentResult Invoke(int pathID, int dayID)
        {
            return View("HiddenQuoteView", _writerPathService.GetQuoteOfTheDay(pathID, dayID).Result);
        }
    }
}