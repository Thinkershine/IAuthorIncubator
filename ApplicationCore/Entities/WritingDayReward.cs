using ApplicationCore.Entities;

namespace Infrastructure.Entities
{
    public class WritingDayReward : BaseEntity
    {
        public int Experience { get; set; }
        public int GoldenPen { get; set; }
    }
}