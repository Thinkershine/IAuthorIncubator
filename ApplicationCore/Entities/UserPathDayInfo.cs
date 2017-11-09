namespace ApplicationCore.Entities
{
    public class UserPathDayInfo
    {
        public int PathId { get; set; }
        public int DayId { get; set; }

        public int WrittenWords { get; set; }
        public bool Accomplished { get; set; }
        public bool Locked { get; set; }
    }
}