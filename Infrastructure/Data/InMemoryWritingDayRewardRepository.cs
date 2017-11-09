using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Entities;
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
                PathId = 0,
                DayId = 0,
                Experience = 25,
                GoldenPen = 2
            } as T);

            Rewards.Add(new WritingDayReward
            {
                Id = 1,
                PathId = 0,
                DayId = 1,
                Experience = 25,
                GoldenPen = 2
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
