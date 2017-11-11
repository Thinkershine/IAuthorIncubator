namespace ApplicationCore.Entities
{
    public class PathDayBody : WritingDay
    {
        public int PathId { get; set; }

        public int WrittenWords { get; set; }
        public bool Accomplished { get; set; }
        public bool Locked { get; set; }
    }
}