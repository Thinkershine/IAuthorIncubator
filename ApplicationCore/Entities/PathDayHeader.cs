namespace ApplicationCore.Entities
{
    public class PathDayHeader
    {
        public int PathDayHeaderID { get; set; }

        public int PathDayNumber { get; set; }
        public int VisibleDayNumber { get; set; } // + Number to Find around in a path... 
        public string HiddenQuoteId { get; set; } // todo : Hidden Quote Repository
        public int RequiredWords { get; set; }

        public int WritingPathID { get; set; }
        public WritingPath WritingPath { get; set; }
        public int WritingDayRewardID { get; set; }
        public WritingDayReward WritingDayReward { get; set; }
    }
}