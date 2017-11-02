using System.Collections.Generic;

namespace WebMVC.ViewModels
{
    public class WritingDayBodyViewModel
    {
        public int Id { get; set; }
        public int PathId { get; set; }
        public string WrittenText { get; set; }
        public string HiddenWisdom { get; set; }
        public IEnumerable<string> ExercisePrompts { get; set; }
    }
}