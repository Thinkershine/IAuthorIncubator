using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryWritingDayHeaderRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly List<T> _inMemoryWritingDayHeaderRepository;

        public InMemoryWritingDayHeaderRepository()
        {
            _inMemoryWritingDayHeaderRepository = new List<T>();
            InitializeDayHeaderRepository();
        }

        private void InitializeDayHeaderRepository()
        {
            Add(new WritingDayHeader
            {
                Id = 0,
                DayId = 0,
                PathId = 0,
                DayNumber = 1,
                HiddenQuote = "Journey of a thousand miles, begins with a single step. ~ Lao Tsu",
                GoldenPenReward = 2,
                ExperienceReward = 25,
                RequiredWords = 50,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 1,
                DayId = 1,
                PathId = 0,
                DayNumber = 2,
                HiddenQuote = "The writing of a novel is taking life as it already exists, not to report it but to make an object, toward the end that the finished work might contain this life inside it and offer it to the reader. The essence will not be, of course, the same thing as the raw material; it is not even of the same family of things. The novel is something that never was before and will not be again.",
                GoldenPenReward = 2,
                ExperienceReward = 25,
                RequiredWords = 50,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 2,
                DayId = 2,
                PathId = 0,
                DayNumber = 3,
                HiddenQuote = null,
                GoldenPenReward = 2,
                ExperienceReward = 25,
                RequiredWords = 100,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 3,
                DayId = 3,
                PathId = 0,
                DayNumber = 4,
                HiddenQuote = null,
                GoldenPenReward = 2,
                ExperienceReward = 25,
                RequiredWords = 100,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 4,
                DayId = 4,
                PathId = 0,
                DayNumber = 5,
                HiddenQuote = null,
                GoldenPenReward = 2,
                ExperienceReward = 25,
                RequiredWords = 150,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 5,
                DayId = 5,
                PathId = 0,
                DayNumber = 6,
                HiddenQuote = null,
                GoldenPenReward = 2,
                ExperienceReward = 25,
                RequiredWords = 150,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 6,
                DayId = 6,
                PathId = 0,
                DayNumber = 7,
                HiddenQuote = null,
                GoldenPenReward = 2,
                ExperienceReward = 25,
                RequiredWords = 200,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 7,
                DayId = 7,
                PathId = 0,
                DayNumber = 8,
                HiddenQuote = null,
                GoldenPenReward = 2,
                ExperienceReward = 25,
                RequiredWords = 200,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 8,
                DayId = 8,
                PathId = 0,
                DayNumber = 9,
                HiddenQuote = null,
                GoldenPenReward = 2,
                ExperienceReward = 25,
                RequiredWords = 250
            } as T);

            Add(new WritingDayHeader
            {
                Id = 9,
                DayId = 9,
                PathId = 0,
                DayNumber = 10,
                HiddenQuote = null,
                GoldenPenReward = 2,
                ExperienceReward = 25,
                RequiredWords = 250,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 10,
                DayId = 10,
                PathId = 0,
                DayNumber = 11,
                HiddenQuote = null,
                GoldenPenReward = 3,
                ExperienceReward = 30,
                RequiredWords = 300,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 11,
                DayId = 11,
                PathId = 0,
                DayNumber = 12,
                HiddenQuote = null,
                GoldenPenReward = 3,
                ExperienceReward = 30,
                RequiredWords = 300,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 12,
                DayId = 12,
                PathId = 0,
                DayNumber = 13,
                HiddenQuote = null,
                GoldenPenReward = 3,
                ExperienceReward = 35,
                RequiredWords = 350,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 13,
                DayId = 13,
                PathId = 0,
                DayNumber = 14,
                HiddenQuote = null,
                GoldenPenReward = 3,
                ExperienceReward = 35,
                RequiredWords = 350,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 14,
                DayId = 14,
                PathId = 0,
                DayNumber = 15,
                HiddenQuote = null,
                GoldenPenReward = 4,
                ExperienceReward = 40,
                RequiredWords = 400,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 15,
                DayId = 15,
                PathId = 0,
                DayNumber = 16,
                HiddenQuote = null,
                GoldenPenReward = 4,
                ExperienceReward = 40,
                RequiredWords = 400,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 16,
                DayId = 16,
                PathId = 0,
                DayNumber = 17,
                HiddenQuote = null,
                GoldenPenReward = 4,
                ExperienceReward = 45,
                RequiredWords = 450,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 17,
                DayId = 17,
                PathId = 0,
                DayNumber = 18,
                HiddenQuote = null,
                GoldenPenReward = 4,
                ExperienceReward = 45,
                RequiredWords = 450,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 18,
                DayId = 18,
                PathId = 0,
                DayNumber = 19,
                HiddenQuote = null,
                GoldenPenReward = 5,
                ExperienceReward = 50,
                RequiredWords = 500,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 19,
                DayId = 19,
                PathId = 0,
                DayNumber = 20,
                HiddenQuote = null,
                GoldenPenReward = 5,
                ExperienceReward = 50,
                RequiredWords = 500,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 20,
                DayId = 20,
                PathId = 0,
                DayNumber = 21,
                HiddenQuote = null,
                GoldenPenReward = 5,
                ExperienceReward = 55,
                RequiredWords = 550,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 21,
                DayId = 21,
                PathId = 0,
                DayNumber = 22,
                HiddenQuote = null,
                GoldenPenReward = 5,
                ExperienceReward = 55,
                RequiredWords = 550,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 22,
                DayId = 22,
                PathId = 0,
                DayNumber = 23,
                HiddenQuote = null,
                GoldenPenReward = 6,
                ExperienceReward = 60,
                RequiredWords = 600,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 23,
                DayId = 23,
                PathId = 0,
                DayNumber = 24,
                HiddenQuote = null,
                GoldenPenReward = 6,
                ExperienceReward = 60,
                RequiredWords = 600,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 24,
                DayId = 24,
                PathId = 0,
                DayNumber = 25,
                HiddenQuote = null,
                GoldenPenReward = 6,
                ExperienceReward = 65,
                RequiredWords = 650,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 25,
                DayId = 25,
                PathId = 0,
                DayNumber = 26,
                HiddenQuote = null,
                GoldenPenReward = 6,
                ExperienceReward = 65,
                RequiredWords = 650,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 26,
                DayId = 26,
                PathId = 0,
                DayNumber = 27,
                HiddenQuote = null,
                GoldenPenReward = 7,
                ExperienceReward = 70,
                RequiredWords = 700,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 27,
                DayId = 27,
                PathId = 0,
                DayNumber = 28,
                HiddenQuote = null,
                GoldenPenReward = 7,
                ExperienceReward = 70,
                RequiredWords = 700,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 28,
                DayId = 28,
                PathId = 0,
                DayNumber = 29,
                HiddenQuote = null,
                GoldenPenReward = 7,
                ExperienceReward = 75,
                RequiredWords = 750,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 29,
                DayId = 29,
                PathId = 0,
                DayNumber = 30,
                HiddenQuote = null,
                GoldenPenReward = 7,
                ExperienceReward = 75,
                RequiredWords = 750,
                WrittenWords = 0
            } as T);
        }

        public T Add(T entity)
        {
            _inMemoryWritingDayHeaderRepository.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _inMemoryWritingDayHeaderRepository.Remove(entity);
        }

        public T GetById(int id)
        {
            return _inMemoryWritingDayHeaderRepository[id];
        }

        public List<T> List()
        {
            return _inMemoryWritingDayHeaderRepository; // TODO: This would return all path's days... !
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
