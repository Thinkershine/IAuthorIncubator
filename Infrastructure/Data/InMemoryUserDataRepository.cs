using ApplicationCore.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryUserDataRepository
    {
        private List<UserPathDayInfo> _userPathDayInfo { get; }
        private List<UserWritingDayBody> _userWritingDayBodies { get; }

        public InMemoryUserDataRepository()
        {
            _userPathDayInfo = new List<UserPathDayInfo>();
            _userWritingDayBodies = new List<UserWritingDayBody>();
            InitializeUserPathDayInfo();
            InitializeUserWritingDayBodies();
        }

        private void InitializeUserPathDayInfo()
        {
            for (int i = 0; i < 30; i += 1)
            {
                _userPathDayInfo.Add(new UserPathDayInfo
                {
                    PathId = 0,
                    DayId = i,
                    WrittenWords = 0,
                    Accomplished = false,
                    Locked = true                
                });
            }
            _userPathDayInfo[0].Locked = false;
        }

        private void InitializeUserWritingDayBodies()
        {
            _userWritingDayBodies.Add(new UserWritingDayBody
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
            });

            for (int i = 1; i < 30; i += 1)
            {
                _userWritingDayBodies.Add(GetEmptyWritingDayBody(i, i, 0));
            }
        }
        private UserWritingDayBody GetEmptyWritingDayBody(int id, int dayId, int pathId)
        {
            return new UserWritingDayBody
            {
                Id = id,
                DayId = dayId,
                PathId = pathId,
                WrittenText = string.Empty,
                HiddenWisdom = string.Empty,
                ExercisePrompts = new string[] { string.Empty }
            };
        }

        public List<UserPathDayInfo> GetUserPathDayInfo()
        {
            return _userPathDayInfo;
        }

        public int GetWrittenWordsForDay(int dayID)
        {
            return _userPathDayInfo[dayID].WrittenWords;
        }

        public UserWritingDayBody GetUserWritingDayBodyById(int dayID)
        {
            return _userWritingDayBodies[dayID];
        }

        public void UpdateUserWritingDayBodyForId(UserWritingDayBody incomingDayBody)
        {
            var dayId = incomingDayBody.DayId;
            _userPathDayInfo[dayId].WrittenWords = incomingDayBody.WrittenWords;
            _userWritingDayBodies[dayId] = incomingDayBody;
        }

        public void AccomplishTheDay(UserPathDayInfo accomplishedDay)
        {
            var dayId = accomplishedDay.DayId;
            _userPathDayInfo[dayId].Accomplished = accomplishedDay.Accomplished;
            var nextId = dayId + 1;
            _userPathDayInfo[nextId].Locked = false; // todo : clean this
            System.Console.WriteLine($"Day Unlocked {_userPathDayInfo[dayId++].Locked}");
        }
    }
}
