using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class WritingPath : BaseEntity
    {
        public string PathName { get; set; }
        public int TotalWords { get; set; }
        public int TotalDays { get; set; }
        public int SevenDaysInARowBonus { get; set; }
        public int FourteenDaysInARowBonus { get; set; }
        public int TwentyOneDaysInARowBonus { get; set; }
        public int CompletionBonus { get; set; }
        public List<int> DayHeaderIds { get; set; }
        //TODO: Develop Trophy public Trophy Trophy { get; set; } 
        //TODO: Develop Achievement public Achievement TotalStreak { get; set; } 
        //TODO: Develop Badge public Badge Badge { get; set; }
    }
}