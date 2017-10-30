using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class WritingPath : BaseEntity
    {
        public string PathName { get; set; }
        public int TotalWords { get; set; } // TOTAL WORDS WRITTEN?
        public int TotalDays { get; set; }
        public int SevenDaysInARowBonus { get; set; }
        public int FourteenDaysInARowBonus { get; set; }
        public int TwentyOneDaysInARowBonus { get; set; }
        public int CompletionBonus { get; set; }
        //TODO: Develop Trophy public Trophy Trophy { get; set; } 
        public List<WritingDayHeader> Days { get; set; }
        public int MissedDays { get; set; }
        //TODO: Develop Achievement public Achievement TotalStreak { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedFinishDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public bool Accomplished { get; set; }
    }
}