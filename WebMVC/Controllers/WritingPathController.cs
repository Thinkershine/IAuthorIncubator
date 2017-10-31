using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebMVC.ViewModels;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    [ViewComponent(Name = "WritingPathComponent")]
    public class WritingPathController : Controller
    {
        private IWriterPathService _writerPathService { get; }

        public WritingPathController(IWriterPathService writerPathService)
        {
            _writerPathService = writerPathService;
        }


        public async Task<WritingDayBodyViewModel> GetPathDayBodyForUserByIds(int pathId, int dayId, string userName)
        {
            return await _writerPathService.GetPathDayBody(pathId, dayId, userName);
        }

        public async Task<IViewComponentResult> InvokeAsync(string userName) => new ViewViewComponentResult()
        {
            ViewData = new ViewDataDictionary<WritingPathViewModel>(ViewData,
                await _writerPathService.GetWritingPathForUser(0, userName))
        };
    }
}