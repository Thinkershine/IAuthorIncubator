using ApplicationCore.Entities;
using Infrastructure.UserData;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryUserDataRepository
    {
        private List<UserPathDayInfo> _userPathDayInfo { get; }
        private List<UserWritingDayBody> _userWritingDayBodies { get; }
        private WriterProfile _writerProfile { get; }

        public InMemoryUserDataRepository(WriterProfile writerProfile)
        {
            _userPathDayInfo = new List<UserPathDayInfo>();
            _userWritingDayBodies = new List<UserWritingDayBody>();
            _writerProfile = writerProfile;
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
            for (int i = 0; i < 30; i += 1)
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
                WrittenWords = 0
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

        public bool RewardReceived(int dayId)
        {
            return _writerProfile.RewardReceived(dayId);
        }

        public void ReceiveReward(int dayId)
        {
            // todo : If giving reward, give it only to the user....
        }
    }
}