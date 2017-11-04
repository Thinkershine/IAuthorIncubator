using System.Collections.Generic;
using WebMVC.ViewModels.UserDTO;

namespace WebMVC.ViewModels
{
    public class WritingPathViewModel
    {
        public int Id { get; set; }
        public string PathName { get; set; }
        public int TotalWords { get; set; }
        public int TotalDays { get; set; }
        public List<WritingDayHeaderViewModel> Days { get; set; }
        public List<UserPathDayInfoViewModel> UserDays { get; set; }
    }
}