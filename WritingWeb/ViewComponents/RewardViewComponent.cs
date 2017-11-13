using Microsoft.AspNetCore.Mvc;
using WritingWeb.ViewModels;

namespace WritingWeb.ViewComponents
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