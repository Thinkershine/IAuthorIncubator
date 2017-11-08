using Infrastructure.Entities;

namespace ApplicationCore.Entities
{
    public class WritingDayHeader : BaseEntity
    {
        public int DayId { get; set; }
        public int PathId { get; set; }
        public int DayNumber { get; set; }
        public string HiddenQuote { get; set; }// todo : Find better way to store hidden quotes ? 
        // perhaps different table
        public WritingDayReward WritingDayReward { get; set; }
        public int GoldenPenReward { get; set; }  // todo : the same applies to golden Pen rewards... they have to go...
        public int ExperienceReward { get; set; } // rward as id -> to Rewards Table... 
        // todo : reward can be calculated from required words 1% and 10%
        public int RequiredWords { get; set; }
    }
}