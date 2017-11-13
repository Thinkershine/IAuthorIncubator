using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryWritingDayRewardRepository : IRepository<WritingDayReward>
    {
        private List<WritingDayReward> Rewards { get; set; }

        public InMemoryWritingDayRewardRepository()
        {
            Rewards = new List<WritingDayReward>();
            InitializeRewards();
        }

        private void InitializeRewards()
        {
            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 0,
                GoldenPen = 2,
                Experience = 25
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 1,
                GoldenPen = 2,
                Experience = 25
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 2,
                GoldenPen = 2,
                Experience = 25
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 3,
                GoldenPen = 2,
                Experience = 25
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 4,
                GoldenPen = 2,
                Experience = 25
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 5,
                GoldenPen = 2,
                Experience = 25
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 6,
                GoldenPen = 2,
                Experience = 25
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 7,
                GoldenPen = 2,
                Experience = 25
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 8,
                GoldenPen = 2,
                Experience = 25
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 9,
                GoldenPen = 2,
                Experience = 25
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 10,
                GoldenPen = 3,
                Experience = 30
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 11,
                GoldenPen = 3,
                Experience = 30
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 12,
                GoldenPen = 3,
                Experience = 35
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 13,
                GoldenPen = 3,
                Experience = 35
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 14,
                GoldenPen = 4,
                Experience = 40
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 15,
                GoldenPen = 4,
                Experience = 40
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 16,
                GoldenPen = 4,
                Experience = 45
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 17,
                GoldenPen = 4,
                Experience = 45
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 18,
                GoldenPen = 5,
                Experience = 50
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 19,
                GoldenPen = 5,
                Experience = 50
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 20,
                GoldenPen = 5,
                Experience = 55
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 21,
                GoldenPen = 5,
                Experience = 55
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 22,
                GoldenPen = 6,
                Experience = 60
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 23,
                GoldenPen = 6,
                Experience = 60
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 24,
                GoldenPen = 6,
                Experience = 65
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 25,
                GoldenPen = 6,
                Experience = 65
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 26,
                GoldenPen = 7,
                Experience = 70
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 27,
                GoldenPen = 7,
                Experience = 70
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 28,
                GoldenPen = 7,
                Experience = 75
            });

            Rewards.Add(new WritingDayReward
            {
                WritingDayRewardID = 29,
                GoldenPen = 7,
                Experience = 75
            });

        }

        public WritingDayReward Add(WritingDayReward entity)
        {
            Rewards.Add(entity);
            return entity;
        }

        WritingDayReward IRepository<WritingDayReward>.GetById(int id)
        {
            return Rewards[id];
        }

        public void Update(WritingDayReward entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(WritingDayReward entity)
        {
            Rewards.Remove(entity);
        }

        List<WritingDayReward> IRepository<WritingDayReward>.List()
        {
            return Rewards;
        }
    }
}