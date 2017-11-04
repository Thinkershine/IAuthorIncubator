using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryWritingPathRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _inMemoryWritingPathRepository;

        public InMemoryWritingPathRepository()
        {
            _inMemoryWritingPathRepository = new List<T>();
            InitializeWritingPath();
        }
        
        private void InitializeWritingPath()
        {
            Add(new WritingPath
            {
                Id = 0,
                PathName = "Developing Writing Habit Path",
                TotalWords = 11100,
                TotalDays = 30,
                SevenDaysInARowBonus = 100,
                FourteenDaysInARowBonus = 200,
                TwentyOneDaysInARowBonus = 300,
                CompletionBonus = 500,
                Days = null,
                DayIds = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 },
                MissedDays = 0,
                StartDate = DateTime.Now,
                EstimatedFinishDate = null,
                FinishDate = null,
                Accomplished = false
            } as T);
        }

        public T Add(T entity)
        {
            _inMemoryWritingPathRepository.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _inMemoryWritingPathRepository.Remove(entity);
        }

        public T GetById(int id)
        {
            return _inMemoryWritingPathRepository[id];
        }

        public List<T> List()
        {
            return _inMemoryWritingPathRepository;
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
