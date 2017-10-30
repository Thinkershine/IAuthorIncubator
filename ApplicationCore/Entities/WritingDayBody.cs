using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class WritingDayBody : BaseEntity
    {
        public int DayId { get; set; }
        public string WrittenText { get; set; }
        public string HiddenQuote { get; set; }
        public string HiddenWisdom { get; set; }
        public IEnumerable<string> ExercisePrompts { get; set; }
    }
}