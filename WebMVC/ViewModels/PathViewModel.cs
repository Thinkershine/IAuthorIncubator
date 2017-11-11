using System.Collections.Generic;
using WebMVC.ViewModels.UserDTO;

namespace WebMVC.ViewModels
{
    public class PathViewModel
    {
        public string PathName { get; set; }
        public int TotalWords { get; set; }
        public int TotalDays { get; set; }
        public List<DayHeaderViewModel> DayHeaders { get; set; }
        public List<UserPathDayInfoViewModel> UserDays { get; set; }
    }
}