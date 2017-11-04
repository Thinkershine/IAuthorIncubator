using Microsoft.AspNetCore.Mvc;
using WebMVC.ViewModels;

namespace WebMVC.ViewComponents
{
    public class WorkingDayViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(WritingDayBodyViewModel writingDayBody)
        {
            return View("WorkingDay", writingDayBody);
        }
    }
}