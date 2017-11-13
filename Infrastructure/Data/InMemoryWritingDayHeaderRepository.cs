using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryWritingDayHeaderRepository : IRepository<PathDayHeader>
    {
        private readonly List<PathDayHeader> _inMemoryWritingDayHeaderRepository;

        public InMemoryWritingDayHeaderRepository()
        {
            _inMemoryWritingDayHeaderRepository = new List<PathDayHeader>();
            InitializeDayHeaderRepository();
        }

        private void InitializeDayHeaderRepository()
        {
            Add(new PathDayHeader
            {
                PathDayHeaderID = 0,
                WritingPathID = 0,
                PathDayNumber = 0,
                VisibleDayNumber = 1,
                HiddenQuoteId = "Journey of a thousand miles, begins with a single step. ~ Lao Tsu",
                WritingDayRewardID = 0,
                RequiredWords = 50
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 1,
                WritingPathID = 0,
                PathDayNumber = 1,
                VisibleDayNumber = 2,
                HiddenQuoteId = "The writing of a novel is taking life as it already exists, not to report it but to make an object, toward the end that the finished work might contain this life inside it and offer it to the reader. The essence will not be, of course, the same thinghe raw material; it is not even of the same family of things. The novel is something that never was before and will not be again.",
                WritingDayRewardID = 1,
                RequiredWords = 50
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 2,
                WritingPathID = 0,
                PathDayNumber = 2,
                VisibleDayNumber = 3,
                HiddenQuoteId = null,
                WritingDayRewardID = 2,
                RequiredWords = 100
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 3,
                WritingPathID = 0,
                PathDayNumber = 3,
                VisibleDayNumber = 4,
                HiddenQuoteId = null,
                WritingDayRewardID = 3,
                RequiredWords = 100
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 4,
                WritingPathID = 0,
                PathDayNumber = 4,
                VisibleDayNumber = 5,
                HiddenQuoteId = null,
                WritingDayRewardID = 4,
                RequiredWords = 150
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 5,
                WritingPathID = 0,
                PathDayNumber = 5,
                VisibleDayNumber = 6,
                HiddenQuoteId = null,
                WritingDayRewardID = 5,
                RequiredWords = 150
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 6,
                WritingPathID = 0,
                PathDayNumber = 6,
                VisibleDayNumber = 7,
                HiddenQuoteId = null,
                WritingDayRewardID = 6,
                RequiredWords = 200
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 7,
                WritingPathID = 0,
                PathDayNumber = 7,
                VisibleDayNumber = 8,
                HiddenQuoteId = null,
                WritingDayRewardID = 7,
                RequiredWords = 200
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 8,
                WritingPathID = 0,
                PathDayNumber= 8,
                VisibleDayNumber = 9,
                HiddenQuoteId = null,
                WritingDayRewardID = 8,
                RequiredWords = 250
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 9,
                WritingPathID = 0,
                PathDayNumber = 9,
                VisibleDayNumber = 10,
                HiddenQuoteId = null,
                WritingDayRewardID = 9,
                RequiredWords = 250
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 10,
                WritingPathID = 0,
                PathDayNumber = 10,
                VisibleDayNumber = 11,
                HiddenQuoteId = null,
                WritingDayRewardID = 10,
                RequiredWords = 300
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 11,
                WritingPathID = 0,
                PathDayNumber = 11,
                VisibleDayNumber = 12,
                HiddenQuoteId = null,
                WritingDayRewardID = 11,
                RequiredWords = 300
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 12,
                WritingPathID = 0,
                PathDayNumber = 12,
                VisibleDayNumber = 13,
                HiddenQuoteId = null,
                WritingDayRewardID = 12,
                RequiredWords = 350
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 13,
                WritingPathID = 0,
                PathDayNumber = 13,
                VisibleDayNumber = 14,
                HiddenQuoteId = null,
                WritingDayRewardID = 13,
                RequiredWords = 350
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 14,
                WritingPathID = 0,
                PathDayNumber = 14,
                VisibleDayNumber = 15,
                HiddenQuoteId = null,
                WritingDayRewardID = 14,
                RequiredWords = 400
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 15,
                WritingPathID = 0,
                PathDayNumber = 15,
                VisibleDayNumber = 16,
                HiddenQuoteId = null,
                WritingDayRewardID = 15,
                RequiredWords = 400
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 16,
                WritingPathID = 0,
                PathDayNumber = 16,
                VisibleDayNumber = 17,
                HiddenQuoteId = null,
                WritingDayRewardID = 16,
                RequiredWords = 450
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 17,
                WritingPathID = 0,
                PathDayNumber = 17,
                VisibleDayNumber = 18,
                HiddenQuoteId = null,
                WritingDayRewardID = 17,
                RequiredWords = 450
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 18,
                WritingPathID = 0,
                PathDayNumber = 18,
                VisibleDayNumber = 19,
                HiddenQuoteId = null,
                WritingDayRewardID = 18,
                RequiredWords = 500
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 19,
                WritingPathID = 0,
                PathDayNumber = 19,
                VisibleDayNumber = 20,
                HiddenQuoteId = null,
                WritingDayRewardID = 19,
                RequiredWords = 500
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 20,
                WritingPathID = 0,
                PathDayNumber = 20,
                VisibleDayNumber = 21,
                HiddenQuoteId = null,
                WritingDayRewardID = 20,
                RequiredWords = 550
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 21,
                WritingPathID = 0,
                PathDayNumber = 21,
                VisibleDayNumber = 22,
                HiddenQuoteId = null,
                WritingDayRewardID = 21,
                RequiredWords = 550
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 22,
                WritingPathID = 0,
                PathDayNumber = 22,
                VisibleDayNumber = 23,
                HiddenQuoteId = null,
                WritingDayRewardID = 22,
                RequiredWords = 600
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 23,
                WritingPathID = 0,
                PathDayNumber = 23,
                VisibleDayNumber = 24,
                HiddenQuoteId = null,
                WritingDayRewardID = 23,
                RequiredWords = 600
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 24,
                WritingPathID = 0,
                PathDayNumber = 24,
                VisibleDayNumber = 25,
                HiddenQuoteId = null,
                WritingDayRewardID = 24,
                RequiredWords = 650
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 25,
                WritingPathID = 0,
                PathDayNumber = 25,
                VisibleDayNumber = 26,
                HiddenQuoteId = null,
                WritingDayRewardID = 25,
                RequiredWords = 650
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 26,
                WritingPathID = 0,
                PathDayNumber = 26,
                VisibleDayNumber = 27,
                HiddenQuoteId = null,
                WritingDayRewardID = 26,
                RequiredWords = 700
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 27,
                WritingPathID = 0,
                PathDayNumber = 27,
                VisibleDayNumber = 28,
                HiddenQuoteId = null,
                WritingDayRewardID = 27,
                RequiredWords = 700
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 28,
                WritingPathID = 0,
                PathDayNumber = 28,
                VisibleDayNumber = 29,
                HiddenQuoteId = null,
                WritingDayRewardID = 28,
                RequiredWords = 750
            });

            Add(new PathDayHeader
            {
                PathDayHeaderID = 29,
                WritingPathID = 0,
                PathDayNumber = 29,
                VisibleDayNumber = 30,
                HiddenQuoteId = null,
                WritingDayRewardID = 29,
                RequiredWords = 750
            });
        }

        public PathDayHeader Add(PathDayHeader entity)
        {
            _inMemoryWritingDayHeaderRepository.Add(entity);
            return entity;
        }

        PathDayHeader IRepository<PathDayHeader>.GetById(int id)
        {
            return _inMemoryWritingDayHeaderRepository[id];
        }

        public void Update(PathDayHeader entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PathDayHeader entity)
        {
            _inMemoryWritingDayHeaderRepository.Remove(entity);
        }

        List<PathDayHeader> IRepository<PathDayHeader>.List()
        {
            return _inMemoryWritingDayHeaderRepository; // TODO: This would return all path's days... !
        }
    }
}