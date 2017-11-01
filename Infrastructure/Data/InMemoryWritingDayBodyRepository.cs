using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryWritingDayBodyRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _inMemoryWritingDayBodyRepository;

        public InMemoryWritingDayBodyRepository()
        {
            _inMemoryWritingDayBodyRepository = new List<T>();
            InitializeDayBodyRepository();
        }

        private void InitializeDayBodyRepository()
        {
            Add(new WritingDayBody
            {
                Id = 0,
                DayId = 0,
                WrittenText = string.Empty,
                HiddenQuote = "Journey of a thousand miles, begins with a single step.",
                HiddenWisdom = "Bird by Bird...",
                ExercisePrompts = new string[] { "Just write" }
            } as T);
        }

        public T Add(T entity)
        {
            _inMemoryWritingDayBodyRepository.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _inMemoryWritingDayBodyRepository.Remove(entity);
        }

        public T GetById(int id)
        {
            return _inMemoryWritingDayBodyRepository[id];
        }

        public List<T> List()
        {
            return _inMemoryWritingDayBodyRepository;
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
