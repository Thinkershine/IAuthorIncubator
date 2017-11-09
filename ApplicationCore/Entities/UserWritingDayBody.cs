namespace ApplicationCore.Entities
{
    public class UserWritingDayBody : BaseEntity
    {
        public int PathId { get; set; }
        public int DayId { get; set; }

        public string WrittenText { get; set; }
        public int WrittenWords { get; set; }
    }
}