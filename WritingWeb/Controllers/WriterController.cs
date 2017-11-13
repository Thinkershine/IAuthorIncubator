using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using WritingWeb.Interfaces;

namespace WritingWeb.Controllers
{
    public class WriterController : Controller
    {
        private IWriterPathService _writerPathService { get; }
        private InMemoryUserDataRepository UserDataRepository { get; set; }

        public WriterController(IWriterPathService writerPathService, InMemoryUserDataRepository userDataRepository)
        {
            _writerPathService = writerPathService;
            UserDataRepository = userDataRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Writer/GetWriter")]
        public IActionResult GetWriter()
        {
            return ViewComponent("WriterProfile");
        }

        [Route("Writer/ClaimReward/{dayID?}")]
        public IActionResult GainExperience(int dayID)
        {
            WritingDayReward reward = _writerPathService.GetReward(dayID).Result;
            UserDataRepository.ReceiveReward(reward, "Thinkershine");

            return ViewComponent("WriterProfile");
        }

        [Route("Writer/DayAccomplished/{dayID?}")]
        public bool DayAccomplished(int dayID)
        {
            // todo day accomplished by accomplished day not by received reward
            bool result = _writerPathService.RewardReceived(dayID);
            return result;
        }
    }
}