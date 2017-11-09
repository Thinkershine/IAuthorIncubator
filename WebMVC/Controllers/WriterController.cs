using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Interfaces;

namespace WebMVC.Controllers
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

        [Route("Writer/GetReward/{pathID?}/{dayID?}")]
        public IActionResult GainExperience(int pathID, int dayID)
        {
            WritingDayReward reward = _writerPathService.GetReward(pathID, dayID).Result;
            UserDataRepository.ReceiveReward(reward, "Thinkershine");

            return ViewComponent("WriterProfile");
        }

        [Route("Writer/DayAccomplished/{dayID?}")]
        public bool DayAccomplished(int dayID)
        {
            bool result = _writerPathService.RewardReceived(dayID);
            return result;
        }
    }
}