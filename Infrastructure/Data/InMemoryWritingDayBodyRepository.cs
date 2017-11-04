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
                PathId = 0,
               // WrittenText = "Most designers set their type arbitrarily, either by pulling values out of the sky or by adhering to a baseline grid. The former case isn’t worth discussing here, but the latter requires a closer look.\n " +
               // "When using a baseline grid, the first thing you must decide on is your baseline grid unit. You’ll commonly see baseline grid values of something like 20px, but where does a value like that come from?\n " +
               // "As you might have guessed, most designers choose this unit arbitrarily. The problem with this approach is that the resulting baseline grid unit is not directly related to the primary font size, which is the most fundamental design element on the page.\n " +
               // "Instead of relying on arbitrary selection, wouldn’t it be nice if there were a way to determine the perfect typography settings based on a given context? \n " +
               // "As it turns out, the golden ratio provides us with a guide—a formula—for proper typesetting. Because of this, we can now set our type with absolute certainty in any situation!Better still, we can use this information about typography to make more informed decisions about all the spatial aspects of our designs, such as:\n " +
               // " - The amount of whitespace that appears after each paragraph\n " +
               // " - Padding, margins, and other units of whitespace throughout the design\n " +
               // " - Headline line - heights in a given width\n " +
               // " - Any and all spatial properties that you wish to relate mathematically" +
               // " - The power of golden ratio typography cannot be understated.By choosing the line - height of your primary text as your new “baseline unit”, you are effectively tying all the dimensions of your layout together with the golden ratio." +
               // "Just look at you, with all this newfound knowledge…the ancient Greeks would be proud :D",
                HiddenWisdom = "Bird by Bird...",
                ExercisePrompts = new string[] { "Just write" }
            } as T);

            for (int i = 1; i < 30; i += 1)
            {
                Add(GetEmptyWritingDayBody(i, i, 0));
            }
            Console.WriteLine($"Current WritingDayBody Days {_inMemoryWritingDayBodyRepository.Count}");
        }

        private T GetEmptyWritingDayBody(int id, int dayId, int pathId)
        {
            return new WritingDayBody
            {
                Id = id,
                DayId = dayId,
                PathId = pathId,
                WrittenText = string.Empty,
                HiddenWisdom = string.Empty,
                ExercisePrompts = new string[] { string.Empty }
            } as T;
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
            _inMemoryWritingDayBodyRepository[entity.Id] = entity;
        }
    }
}
