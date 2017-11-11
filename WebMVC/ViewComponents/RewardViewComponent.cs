using Microsoft.AspNetCore.Mvc;
using WebMVC.ViewModels;

namespace WebMVC.ViewComponents
{
    public class RewardViewComponent : ViewComponent
    {
        public RewardViewComponent()
        {
        }

        public IViewComponentResult Invoke(RewardViewModel reward)
        {
            return View("Reward", reward);
        }
    }
}