using Infrastructure.Entities;
using Infrastructure.UserData;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebMVC.Interfaces;

namespace WebMVC.Controllers
{
    public class WriterController : Controller
    {
        private IWriterPathService _writerPathService { get; }
        private WriterProfile WriterProfile { get; set; }

        public WriterController(IWriterPathService writerPathService, WriterProfile writerProfile)
        {
            _writerPathService = writerPathService;
            WriterProfile = writerProfile;
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
            WriterProfile.ReceiveReward(reward);

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