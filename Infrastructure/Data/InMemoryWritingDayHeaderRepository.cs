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
            Add(new PathDayHeader
            {
                Id = 0,
                PathId = 0,
                PathDayId = 0,
                VisibleDayNumber = 1,
                HiddenQuoteId = "Journey of a thousand miles, begins with a single step. ~ Lao Tsu",
                RewardId = 0,
                RequiredWords = 50
            } as T);

            Add(new PathDayHeader
            {
                Id = 1,
                PathId = 0,
                PathDayId = 1,
                VisibleDayNumber = 2,
                HiddenQuoteId = "The writing of a novel is taking life as it already exists, not to report it but to make an object, toward the end that the finished work might contain this life inside it and offer it to the reader. The essence will not be, of course, the same thing as the raw material; it is not even of the same family of things. The novel is something that never was before and will not be again.",
                RewardId = 1,
                RequiredWords = 50
            } as T);

            Add(new PathDayHeader
            {
                Id = 2,
                PathId = 0,
                PathDayId = 2,
                VisibleDayNumber = 3,
                HiddenQuoteId = null,
                RewardId = 2,
                RequiredWords = 100
            } as T);

            Add(new PathDayHeader
            {
                Id = 3,
                PathId = 0,
                PathDayId = 3,
                VisibleDayNumber = 4,
                HiddenQuoteId = null,
                RewardId = 3,
                RequiredWords = 100
            } as T);

            Add(new PathDayHeader
            {
                Id = 4,
                PathId = 0,
                PathDayId = 4,
                VisibleDayNumber = 5,
                HiddenQuoteId = null,
                RewardId = 4,
                RequiredWords = 150
            } as T);

            Add(new PathDayHeader
            {
                Id = 5,
                PathId = 0,
                PathDayId = 5,
                VisibleDayNumber = 6,
                HiddenQuoteId = null,
                RewardId = 5,
                RequiredWords = 150
            } as T);

            Add(new PathDayHeader
            {
                Id = 6,
                PathId = 0,
                PathDayId = 6,
                VisibleDayNumber = 7,
                HiddenQuoteId = null,
                RewardId = 6,
                RequiredWords = 200
            } as T);

            Add(new PathDayHeader
            {
                Id = 7,
                PathId = 0,
                PathDayId = 7,
                VisibleDayNumber = 8,
                HiddenQuoteId = null,
                RewardId = 7,
                RequiredWords = 200
            } as T);

            Add(new PathDayHeader
            {
                Id = 8,
                PathId = 0,
                PathDayId = 8,
                VisibleDayNumber = 9,
                HiddenQuoteId = null,
                RewardId = 8,
                RequiredWords = 250
            } as T);

            Add(new PathDayHeader
            {
                Id = 9,
                PathId = 0,
                PathDayId = 9,
                VisibleDayNumber = 10,
                HiddenQuoteId = null,
                RewardId = 9,
                RequiredWords = 250
            } as T);

            Add(new PathDayHeader
            {
                Id = 10,
                PathId = 0,
                PathDayId = 10,
                VisibleDayNumber = 11,
                HiddenQuoteId = null,
                RewardId = 10,
                RequiredWords = 300
            } as T);

            Add(new PathDayHeader
            {
                Id = 11,
                PathId = 0,
                PathDayId = 11,
                VisibleDayNumber = 12,
                HiddenQuoteId = null,
                RewardId = 11,
                RequiredWords = 300
            } as T);

            Add(new PathDayHeader
            {
                Id = 12,
                PathId = 0,
                PathDayId = 12,
                VisibleDayNumber = 13,
                HiddenQuoteId = null,
                RewardId = 12,
                RequiredWords = 350
            } as T);

            Add(new PathDayHeader
            {
                Id = 13,
                PathId = 0,
                PathDayId = 13,
                VisibleDayNumber = 14,
                HiddenQuoteId = null,
                RewardId = 13,
                RequiredWords = 350
            } as T);

            Add(new PathDayHeader
            {
                Id = 14,
                PathId = 0,
                PathDayId = 14,
                VisibleDayNumber = 15,
                HiddenQuoteId = null,
                RewardId = 14,
                RequiredWords = 400
            } as T);

            Add(new PathDayHeader
            {
                Id = 15,
                PathId = 0,
                PathDayId = 15,
                VisibleDayNumber = 16,
                HiddenQuoteId = null,
                RewardId = 15,
                RequiredWords = 400
            } as T);

            Add(new PathDayHeader
            {
                Id = 16,
                PathId = 0,
                PathDayId = 16,
                VisibleDayNumber = 17,
                HiddenQuoteId = null,
                RewardId = 16,
                RequiredWords = 450
            } as T);

            Add(new PathDayHeader
            {
                Id = 17,
                PathId = 0,
                PathDayId = 17,
                VisibleDayNumber = 18,
                HiddenQuoteId = null,
                RewardId = 17,
                RequiredWords = 450
            } as T);

            Add(new PathDayHeader
            {
                Id = 18,
                PathId = 0,
                PathDayId = 18,
                VisibleDayNumber = 19,
                HiddenQuoteId = null,
                RewardId = 18,
                RequiredWords = 500
            } as T);

            Add(new PathDayHeader
            {
                Id = 19,
                PathId = 0,
                PathDayId = 19,
                VisibleDayNumber = 20,
                HiddenQuoteId = null,
                RewardId = 19,
                RequiredWords = 500
            } as T);

            Add(new PathDayHeader
            {
                Id = 20,
                PathId = 0,
                PathDayId = 20,
                VisibleDayNumber = 21,
                HiddenQuoteId = null,
                RewardId = 20,
                RequiredWords = 550
            } as T);

            Add(new PathDayHeader
            {
                Id = 21,
                PathId = 0,
                PathDayId = 21,
                VisibleDayNumber = 22,
                HiddenQuoteId = null,
                RewardId = 21,
                RequiredWords = 550
            } as T);

            Add(new PathDayHeader
            {
                Id = 22,
                PathId = 0,
                PathDayId = 22,
                VisibleDayNumber = 23,
                HiddenQuoteId = null,
                RewardId = 22,
                RequiredWords = 600
            } as T);

            Add(new PathDayHeader
            {
                Id = 23,
                PathId = 0,
                PathDayId = 23,
                VisibleDayNumber = 24,
                HiddenQuoteId = null,
                RewardId = 23,
                RequiredWords = 600
            } as T);

            Add(new PathDayHeader
            {
                Id = 24,
                PathId = 0,
                PathDayId = 24,
                VisibleDayNumber = 25,
                HiddenQuoteId = null,
                RewardId = 24,
                RequiredWords = 650
            } as T);

            Add(new PathDayHeader
            {
                Id = 25,
                PathId = 0,
                PathDayId = 25,
                VisibleDayNumber = 26,
                HiddenQuoteId = null,
                RewardId = 25,
                RequiredWords = 650
            } as T);

            Add(new PathDayHeader
            {
                Id = 26,
                PathId = 0,
                PathDayId = 26,
                VisibleDayNumber = 27,
                HiddenQuoteId = null,
                RewardId = 26,
                RequiredWords = 700
            } as T);

            Add(new PathDayHeader
            {
                Id = 27,
                PathId = 0,
                PathDayId = 27,
                VisibleDayNumber = 28,
                HiddenQuoteId = null,
                RewardId = 27,
                RequiredWords = 700
            } as T);

            Add(new PathDayHeader
            {
                Id = 28,
                PathId = 0,
                PathDayId = 28,
                VisibleDayNumber = 29,
                HiddenQuoteId = null,
                RewardId = 28,
                RequiredWords = 750
            } as T);

            Add(new PathDayHeader
            {
                Id = 29,
                PathId = 0,
                PathDayId = 29,
                VisibleDayNumber = 30,
                HiddenQuoteId = null,
                RewardId = 29,
                RequiredWords = 750
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
