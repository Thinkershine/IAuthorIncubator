namespace ApplicationCore.Entities
{
    public class PathDayBody
    {
        public int PathDayBodyID { get; set; }

        public int WrittenWords { get; set; }
        public bool Accomplished { get; set; }
        public bool Locked { get; set; }

        public int WritingPathID { get; set; }
        public WritingPath WritingPath { get; set; }
    }
}