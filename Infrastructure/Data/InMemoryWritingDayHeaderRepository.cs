﻿using ApplicationCore.Entities;
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
                DayId = 1,
                PathId = 0,
                DayNumber = 1,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 50,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 1,
                DayId = 2,
                PathId = 0,
                DayNumber = 2,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 50,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 2,
                DayId = 3,
                PathId = 0,
                DayNumber = 3,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 100,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 3,
                DayId = 4,
                PathId = 0,
                DayNumber = 4,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 100,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 4,
                DayId = 5,
                PathId = 0,
                DayNumber = 5,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 150,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 5,
                DayId = 6,
                PathId = 0,
                DayNumber = 6,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 150,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 6,
                DayId = 7,
                PathId = 0,
                DayNumber = 7,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 200,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 7,
                DayId = 8,
                PathId = 0,
                DayNumber = 8,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 200,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 8,
                DayId = 9,
                PathId = 0,
                DayNumber = 9,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 250,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 9,
                DayId = 10,
                PathId = 0,
                DayNumber = 10,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 250,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 10,
                DayId = 11,
                PathId = 0,
                DayNumber = 11,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 300,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 11,
                DayId = 12,
                PathId = 0,
                DayNumber = 12,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 300,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 12,
                DayId = 13,
                PathId = 0,
                DayNumber = 13,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 350,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 13,
                DayId = 14,
                PathId = 0,
                DayNumber = 14,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 350,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 14,
                DayId = 15,
                PathId = 0,
                DayNumber = 15,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 400,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 15,
                DayId = 16,
                PathId = 0,
                DayNumber = 16,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 400,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 16,
                DayId = 17,
                PathId = 0,
                DayNumber = 17,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 450,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 17,
                DayId = 18,
                PathId = 0,
                DayNumber = 18,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 450,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 18,
                DayId = 19,
                PathId = 0,
                DayNumber = 19,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 500,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 19,
                DayId = 20,
                PathId = 0,
                DayNumber = 20,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 500,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 20,
                DayId = 21,
                PathId = 0,
                DayNumber = 21,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 550,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 21,
                DayId = 22,
                PathId = 0,
                DayNumber = 22,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 550,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 22,
                DayId = 23,
                PathId = 0,
                DayNumber = 23,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 600,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 23,
                DayId = 24,
                PathId = 0,
                DayNumber = 24,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 600,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 24,
                DayId = 25,
                PathId = 0,
                DayNumber = 25,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 650,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 25,
                DayId = 26,
                PathId = 0,
                DayNumber = 26,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 650,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 26,
                DayId = 27,
                PathId = 0,
                DayNumber = 27,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 700,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 27,
                DayId = 28,
                PathId = 0,
                DayNumber = 28,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 700,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 28,
                DayId = 29,
                PathId = 0,
                DayNumber = 29,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
                RequiredWords = 750,
                WrittenWords = 0
            } as T);

            Add(new WritingDayHeader
            {
                Id = 29,
                DayId = 30,
                PathId = 0,
                DayNumber = 30,
                RewardReceived = false,
                ExperienceReward = 25,
                AccomplishedDate = null,
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