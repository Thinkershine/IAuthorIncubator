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

        public IViewComponentResult Invoke(int dayID)
        {
            return View("HiddenQuote", _writerPathService.GetQuoteOfTheDay(dayID).Result);
        }
    }
}