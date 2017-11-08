using Infrastructure.UserData;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.ViewComponents
{
    public class WriterProfileViewComponent : ViewComponent
    {
        private WriterProfile WriterProfile { get; }

        public WriterProfileViewComponent(WriterProfile writerProfile)
        {
            WriterProfile = writerProfile;
        }

        public IViewComponentResult Invoke()
        {
            return View("WriterProfile", WriterProfile);
        }
    }
}
