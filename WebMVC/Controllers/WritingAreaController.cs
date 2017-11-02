using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class WritingAreaController : Controller
    {
        private IWriterPathService _writerPathService;

        public WritingAreaController(IWriterPathService writerPathSerivce)
        {
            _writerPathService = writerPathSerivce;
        }

        [Route("WritingArea/GetDay/{path?}/{day?}")]
        public IActionResult GetDay(int path, int day)
        {
            int[] temp = new int[] { path, day };
            return ViewComponent("WorkingDay", temp);
        }

        public void SaveDay(WritingDayBodyViewModel incomingDay)
        {
            if (ModelState.IsValid)
            {
                //_writerPathService.SaveTheDay(incomingDay);
                System.Console.WriteLine($"Saving The Day {incomingDay}");
            }
        }
    }
}