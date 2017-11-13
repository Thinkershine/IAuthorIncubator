using System.Collections.Generic;
using WritingWeb.ViewModels.UserDTO;

namespace WritingWeb.ViewModels
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