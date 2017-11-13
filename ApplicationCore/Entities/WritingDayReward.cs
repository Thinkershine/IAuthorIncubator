using ApplicationCore.Entities;

namespace ApplicationCore.Entities
{
    public class WritingDayReward : BaseEntity
    {
        public int Experience { get; set; }
        public int GoldenPen { get; set; }
    }
}