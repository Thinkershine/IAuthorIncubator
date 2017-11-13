using Microsoft.AspNetCore.Mvc;
using WritingWeb.ViewModels;
using ApplicationCore.Entities;
using WritingWeb.Interfaces;

namespace WritingWeb.Controllers
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

        [Route("WritingArea/GetDay/{dayID?}")]
        public IActionResult GetDay(int dayID)
        {
            var workingDayBodyViewModel = _writerPathService.GetPathDayBody(dayID).Result;
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
                var reward = _writerPathService.GetReward(dayID).Result;
                RewardViewModel rewardModel = new RewardViewModel
                {
                    Id = reward.Id,
                    Experience = reward.Experience,
                    GoldenPen = reward.GoldenPen
                };

                // todo: Get reward from REWARDS REPOSITORY NOT FROM DAY REPOSITORY !

                return ViewComponent("Reward", rewardModel);
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [Route("WritingArea/SaveDay/{dayID?}")]
        public void SaveDay([FromBody]DayBodyViewModel writingDayBody)
        {
            if (ModelState.IsValid)
            {
                // TODO : IF day already exists? Don't add new, but edit old one...
                UserDayBody newDayBody = new UserDayBody
                {
                    Id = writingDayBody.Id,
                    PathDayId = writingDayBody.DayId,
                    PathId = writingDayBody.PathId,
                    WrittenText = writingDayBody.WrittenText,
                    WrittenWords = writingDayBody.WrittenWords
                };

                _storageService.SaveDay(newDayBody);
            }
        }

        [Route("WritingArea/AccomplishDay/{dayID?}")]
        public void DayAccomplished(int dayID)
        {
            _storageService.AccomplishDay(dayID);
        }
    }
}