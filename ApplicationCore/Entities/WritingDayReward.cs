namespace ApplicationCore.Entities
{
    public class WritingDayReward
    {
        public int WritingDayRewardID { get; set; }

        public int Experience { get; set; }
        public int GoldenPen { get; set; }

        public int PathDayHeaderID { get; set; }
        public PathDayHeader PathDayHeader { get; set; }
    }
}