using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public float CurrentLevelPercentage { get; set; }
        public WriterStatus WriterStatus { get; set; }
        public int GoldenPens { get; set; }

        public bool Author { get; set; }

        public List<int> ReceivedRewards { get; set; }

        private Dictionary<int, int> ExperienceTable { get; set; }

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
            WriterStatus = WriterStatus.Newbie;

            Author = false;
            ReceivedRewards = new List<int>();

            InitializeExperienceTable();
        }
        private void InitializeExperienceTable()
        {
            int baseExp = 100;
            int maximumLevel = 100;
            ExperienceTable = new Dictionary<int, int>
            {
                { 1, baseExp }
            };

            for (int i = 2; i < maximumLevel; i += 1)
            {
                ExperienceTable.Add(i, ExperienceTable[i - 1] + (baseExp / 2) * 10);
            }
        }

        public void CalculateCurrentLevelPercentage()
        {
            var expForNextWriterLevel = ExperienceTable[WritingLevel + 1];
            CurrentLevelPercentage = (WritingExperience * 100) / expForNextWriterLevel;
            if (CurrentLevelPercentage >= 1)
            {
                WritingLevel += 1;
            }
            
            var expForNextLevel = (float)WriterStatus + 1;
            var currentLevelWriterStatusPercentage = (WritingExperience * 100) / expForNextLevel;
            if (currentLevelWriterStatusPercentage >= 1) // todo : change to better experience later... 
            {
                // Writer Status Grows with Expreience But Not With Every Level...
                WriterStatus nextLevel = Enum.GetValues(typeof(WriterStatus)).Cast<WriterStatus>()
                    .First(val => (int)val > (int)WriterStatus);
                WriterStatus = nextLevel;
            }
        }

        public void ReceiveReward(WritingDayReward receivedReward)
        {
            if(StoreReward(receivedReward.Id))
            {
                WritingExperience += receivedReward.Experience;
                GoldenPens += receivedReward.GoldenPen;
                CalculateCurrentLevelPercentage();
            }
        }

        private bool StoreReward(int id)
        {
            bool stored = false;
            if (ReceivedRewards.Contains(id))
            {
                return stored;
            }
            else
            {
                ReceivedRewards.Add(id); // todo Find such id reward and set it to true
                stored = true;
                return stored;
            }
        }

        public bool RewardReceived(int rewardID)
        {
            if(ReceivedRewards.Contains(rewardID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}