﻿namespace ApplicationCore.Entities
{
    public class DayHeader : BaseEntity
    {
        public int PathId { get; set; }
        public int VisibleDayNumber { get; set; }
        public string HiddenQuoteId { get; set; } // todo : Hidden Quote Repository
        public int RewardId { get; set; }
        public int RequiredWords { get; set; }
    }
}