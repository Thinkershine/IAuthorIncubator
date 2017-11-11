namespace ApplicationCore.Entities
{
    public class UserDayBody : WritingDay
    {
        public int PathId { get; set; }

        public string WrittenText { get; set; }
        public int WrittenWords { get; set; }
    }
}