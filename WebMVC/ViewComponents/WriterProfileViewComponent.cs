using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.ViewComponents
{
    public class WriterProfileViewComponent : ViewComponent
    {
        private InMemoryUserDataRepository Users { get; }

        public WriterProfileViewComponent(InMemoryUserDataRepository users)
        {
            Users = users;
        }

        public IViewComponentResult Invoke()
        {
            return View("WriterProfile", Users.GetUserWriterProfile("Thinkershine"));
        }
    }
}