using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WritingWeb.ViewModels
{
    public class DayBodyViewModel
    {
        public int UserDayBodyID { get; set; }
        [Required]
        public int PathDayNumber { get; set; }
        [Required]
        public int WritingPathID { get; set; }
        [Required]
        public string WrittenText { get; set; }
        [Required]
        public int WrittenWords { get; set; }
        public string HiddenWisdom { get; set; }
        public IEnumerable<string> ExercisePrompts { get; set; }
    }
}