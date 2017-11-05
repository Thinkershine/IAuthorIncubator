using System.Collections.Generic;

namespace Infrastructure.UserData
{
    public enum WriterStatus
    {
        Newbie = 999,
        Wannabie = 2499,
        Apprentice = 4999,
        Journeyman = 9999,
        Master = 19999,
        Expert = 24999,
        Artisan = 49999
    }

    public class WriterProfile
    {
        public List<int> WritingPaths { get; set; }
        public string PenName { get; set; }
        public int WritingLevel { get; set; }
        public int WritingExperience { get; set; }
        public int CurrentLevelPercentage { get; set; }
        public WriterStatus WriterStatus { get; set; }
        public int GoldenPens { get; set; }

        public bool Author { get; set; }

        public WriterProfile()
        {
            WritingPaths = new List<int>
            {
                0
            };

            PenName = "Thinkershine";
            WritingLevel = 0;
            WritingExperience = 0;
            GoldenPens = 10;
            WriterStatus = WriterStatus.Artisan;

            Author = false;
        }
    }
}