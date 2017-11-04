using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.ViewModels
{
    public class WritingDayBodyViewModel
    {
        public int Id { get; set; }
        [Required]
        public int DayId { get; set; }
        [Required]
        public int PathId { get; set; }
        [Required]
        public string WrittenText { get; set; }
        public string HiddenWisdom { get; set; }
        public IEnumerable<string> ExercisePrompts { get; set; }
    }
}