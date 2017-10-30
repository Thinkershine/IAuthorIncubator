using System.Collections.Generic;

namespace WebMVC.ViewModels
{
    public class WritingPathViewModel
    {
        public int Id { get; set; }
        public string PathName { get; set; }
        public int TotalWords { get; set; }
        public int TotalDays { get; set; }
        public List<WritingDayHeaderViewModel> Days { get; set; }
    }
}