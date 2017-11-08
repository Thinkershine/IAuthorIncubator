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
            if (_writerPathService.RewardReceived(dayID))
            {
                return Ok();
            }
            else
            {
                var reward = _writerPathService.GetReward(0, dayID).Result;
                var xpReward = reward.Experience;
                var goldenPenReward = reward.GoldenPen;

                // todo: Get reward from REWARDS REPOSITORY NOT FROM DAY REPOSITORY !

                return ViewComponent("Reward", new { xpReward, goldenPenReward });
            }
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

                _storageService.SaveDay(newDayBody);
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

                _storageService.AccomplishDay(newAccomplishedDay);
            }
        }

    }
}