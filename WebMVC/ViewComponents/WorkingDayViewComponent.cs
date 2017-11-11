using Microsoft.AspNetCore.Mvc;
using WebMVC.ViewModels;

namespace WebMVC.ViewComponents
{
    public class WorkingDayViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DayBodyViewModel writingDayBody)
        {
            return View("WorkingDay", writingDayBody);
        }
    }
}