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

        [Route("WritingArea/GetDay/{pathID?}/{dayID?}")]
        public IActionResult GetDay(int pathID, int dayID)
        {
            int[] temp = new int[] { pathID, dayID };
            return ViewComponent("WorkingDay", temp);
        }

        [Route("WritingArea/GetAchievement/{id?}")]
        public IActionResult GetAchievement(int id)
        {
            // Todo: Store achievement at user account
            // Todo: Display achievement
            return ViewComponent("Achievement", id);
        }

        [Route("WritingArea/GetReward/{dayID?}")]
        public IActionResult GetReward(int dayID)
        {
            // Todo: Check if the day is not already acomplished
            var particularDay = _writerPathService.GetPathDayHeader(0, dayID, "Thinkershine").Result;
            var xpReward = particularDay.ExperienceReward;
            var goldenPenReward = particularDay.GoldenPenReward;
            // Todo: Check if the day is unlocked
            // Todo: Reward user for completion
            // Todo: Display reward to the user

            return ViewComponent("Reward", new { xpReward, goldenPenReward });
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