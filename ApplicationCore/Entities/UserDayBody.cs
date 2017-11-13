namespace ApplicationCore.Entities
{
    public class UserDayBody
    {
        public int UserDayBodyID { get; set; }

        public int PathDayNumber { get; set; }
        public string WrittenText { get; set; }
        public int WrittenWords { get; set; }

        public int WritingPathID { get; set; }
        public WritingPath WritingPath { get; set; }
    }
}