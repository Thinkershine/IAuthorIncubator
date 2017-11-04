using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class UserWritingDayBody : BaseEntity
    {
        public int DayId { get; set; }
        public int PathId { get; set; }
        public string WrittenText { get; set; }
        public string HiddenWisdom { get; set; }
        public IEnumerable<string> ExercisePrompts { get; set; }
    }
}