using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class UserWritingPathStoreData
    {
        // USER-Writing-Path-Store-Data
        // TOTAL WORDS WRITTEN?
        public int MissedDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EstimatedFinishDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public bool Accomplished { get; set; }
    }
}
