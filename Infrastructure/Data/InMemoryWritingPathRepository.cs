using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryWritingPathRepository : IRepository<WritingPath>
    {
        private readonly List<WritingPath> _inMemoryWritingPathRepository;

        public InMemoryWritingPathRepository()
        {
            _inMemoryWritingPathRepository = new List<WritingPath>();
            InitializeWritingPath();
        }
        
        private void InitializeWritingPath()
        {
            Add(new WritingPath
            {
                WritingPathID = 0,
                PathName = "Developing Writing Habit Path",
                TotalWords = 11100,
                TotalDays = 30,
                SevenDaysInARowBonus = 100,
                FourteenDaysInARowBonus = 200,
                TwentyOneDaysInARowBonus = 300,
                CompletionBonus = 500,
                DayHeaderIds = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 }
            });
        }

        public WritingPath Add(WritingPath entity)
        {
            _inMemoryWritingPathRepository.Add(entity);
            return entity;
        }

        WritingPath IRepository<WritingPath>.GetById(int id)
        {
            return _inMemoryWritingPathRepository[id];
        }

        public void Update(WritingPath entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(WritingPath entity)
        {
            _inMemoryWritingPathRepository.Remove(entity);
        }

        List<WritingPath> IRepository<WritingPath>.List()
        {
            return _inMemoryWritingPathRepository;
        }
    }
}
