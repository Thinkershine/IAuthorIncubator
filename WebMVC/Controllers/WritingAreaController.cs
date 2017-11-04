using Microsoft.AspNetCore.Mvc;
using WebMVC.ViewModels;
using ApplicationCore.Entities;
using WebMVC.Interfaces;
using WebMVC.ViewModels.UserDTO;

namespace WebMVC.Controllers
{
    public class WritingAreaController : Controller
    {
        private IWriterPathService _writerPathService;
        private IStorageService _storageService;

        public WritingAreaController(IWriterPathService writerPathSerivce, 
            IStorageService storageService)
        {
            _writerPathService = writerPathSerivce;
            _storageService = storageService;
        }

        [Route("WritingArea/GetDay/{pathID?}/{dayID?}")]
        public IActionResult GetDay(int pathID, int dayID)
        {
            var workingDayBodyViewModel = _writerPathService.GetPathDayBody(pathID, dayID, "Thinkershine").Result;
            return ViewComponent("WorkingDay", workingDayBodyViewModel);
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

        [HttpPost]
        [Consumes("application/json")]
        [Route("WritingArea/SaveDay/{dayID?}")]
        public void SaveDay([FromBody]WritingDayBodyViewModel writingDayBody)
        {
            if (ModelState.IsValid)
            {
                UserWritingDayBody newDayBody = new UserWritingDayBody
                {
                    Id = writingDayBody.Id,
                    DayId = writingDayBody.DayId,
                    PathId = writingDayBody.PathId,
                    WrittenText = writingDayBody.WrittenText,
                    WrittenWords = writingDayBody.WrittenWords
                };

                _storageService.SaveTheDay(newDayBody);
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [Route("WritingArea/DayAccomplished/{dayID?}")]
        public void DayAccomplished([FromBody]UserPathDayInfoViewModel accomplishedDay)
        {
            if (ModelState.IsValid)
            {
                UserPathDayInfo newAccomplishedDay = new UserPathDayInfo
                {
                    PathId = accomplishedDay.PathId,
                    DayId = accomplishedDay.DayId,
                    Accomplished = true
                };

                _storageService.AccomplishTheDay(newAccomplishedDay);
            }
        }

    }
}