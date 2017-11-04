using Microsoft.AspNetCore.Mvc;

namespace WebMVC.ViewComponents
{
    public class RewardViewComponent : ViewComponent
    {
        public RewardViewComponent()
        {
        }

        // todo : receive reward
        public IViewComponentResult Invoke(int xpReward, int goldenPenReward)
        {
            return View("Reward", new int[] { xpReward, goldenPenReward });
        }
    }
}