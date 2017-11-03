using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return View("RewardView", new int[] { xpReward, goldenPenReward });
        }
    }
}
