using ApplicationCore.Entities;

namespace Infrastructure.Entities
{
    public class WritingDayReward : BaseEntity
    {
        public int PathId { get; set; }
        public int DayId { get; set; }

        public int Experience { get; set; }
        public int GoldenPen { get; set; }
        public bool Received { get; set; }
    }
}