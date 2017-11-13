using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryWritingDayRewardRepository<T> : IRepository<T> where T : BaseEntity
    {
        private List<T> Rewards { get; set; }

        public InMemoryWritingDayRewardRepository()
        {
            Rewards = new List<T>();
            InitializeRewards();
        }

        private void InitializeRewards()
        {
            Rewards.Add(new WritingDayReward
            {
                Id = 0,
                GoldenPen = 2,
                Experience = 25
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 1,
                GoldenPen = 2,
                Experience = 25
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 2,
                GoldenPen = 2,
                Experience = 25
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 3,
                GoldenPen = 2,
                Experience = 25
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 4,
                GoldenPen = 2,
                Experience = 25
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 5,
                GoldenPen = 2,
                Experience = 25
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 6,
                GoldenPen = 2,
                Experience = 25
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 7,
                GoldenPen = 2,
                Experience = 25
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 8,
                GoldenPen = 2,
                Experience = 25
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 9,
                GoldenPen = 2,
                Experience = 25
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 10,
                GoldenPen = 3,
                Experience = 30
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 11,
                GoldenPen = 3,
                Experience = 30
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 12,
                GoldenPen = 3,
                Experience = 35
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 13,
                GoldenPen = 3,
                Experience = 35
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 14,
                GoldenPen = 4,
                Experience = 40
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 15,
                GoldenPen = 4,
                Experience = 40
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 16,
                GoldenPen = 4,
                Experience = 45
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 17,
                GoldenPen = 4,
                Experience = 45
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 18,
                GoldenPen = 5,
                Experience = 50
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 19,
                GoldenPen = 5,
                Experience = 50
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 20,
                GoldenPen = 5,
                Experience = 55
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 21,
                GoldenPen = 5,
                Experience = 55
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 22,
                GoldenPen = 6,
                Experience = 60
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 23,
                GoldenPen = 6,
                Experience = 60
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 24,
                GoldenPen = 6,
                Experience = 65
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 25,
                GoldenPen = 6,
                Experience = 65
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 26,
                GoldenPen = 7,
                Experience = 70
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 27,
                GoldenPen = 7,
                Experience = 70
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 28,
                GoldenPen = 7,
                Experience = 75
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 29,
                GoldenPen = 7,
                Experience = 75
            } as T);

        }

        public T Add(T entity)
        {
            Rewards.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            Rewards.Remove(entity);
        }

        public T GetById(int id)
        {
            return Rewards[id];
        }

        public List<T> List()
        {
            return Rewards;
        }

        public List<T> List(ISpecification<T> spec)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
