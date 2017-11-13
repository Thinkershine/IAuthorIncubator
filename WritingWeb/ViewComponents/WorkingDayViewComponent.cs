using Microsoft.AspNetCore.Mvc;
using WritingWeb.ViewModels;

namespace WritingWeb.ViewComponents
{
    public class WorkingDayViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DayBodyViewModel writingDayBody)
        {
            return View("WorkingDay", writingDayBody);
        }
    }
}