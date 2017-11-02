using System;

namespace ApplicationCore.Entities
{
    public class WritingDayHeader : BaseEntity
    {
        public int DayId { get; set; }
        public int PathId { get; set; }
        public int DayNumber { get; set; }
        public string HiddenQuote { get; set; }
        // TODO: GoldenPen Reward public GoldenPen Reward { get; set; } 
        public bool RewardReceived { get; set; }
        public int ExperienceReward { get; set; }
        public DateTime? AccomplishedDate { get; set; }
        public int RequiredWords { get; set; }
        public int WrittenWords { get; set; }
    }
}