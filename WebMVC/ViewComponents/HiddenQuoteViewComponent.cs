using Microsoft.AspNetCore.Mvc;
using WebMVC.Interfaces;

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
            return View("HiddenQuote", _writerPathService.GetQuoteOfTheDay(pathID, dayID).Result);
        }
    }
}