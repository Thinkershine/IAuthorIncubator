using ApplicationCore.Entities;
using Infrastructure.Entities;
using System.Collections.Generic;

namespace Infrastructure.UserData
{
    public class User
    {
        private List<UserPathDayInfo> _userPathDayInfo { get; }
        private List<UserWritingDayBody> _userWritingDayBodies { get; }
        private WriterProfile _writerProfile { get; }

        public User()
        {
            _userPathDayInfo = new List<UserPathDayInfo>();
            _userWritingDayBodies = new List<UserWritingDayBody>();
            _writerProfile = new WriterProfile();

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

        public WriterProfile GetWriterProfile()
        {
            return _writerProfile;
        }

        public List<UserPathDayInfo> GetUserPathDayInfo()
        {
            return _userPathDayInfo;
        }

        public int GetWrittenWordsForDay(int dayID)
        {
            return _userPathDayInfo[dayID].WrittenWords;
        }

        public UserWritingDayBody GetWritingDayBody(int dayID)
        {
            return _userWritingDayBodies[dayID];
        }

        public void UpdateUserWritingDay(UserWritingDayBody incomingDayBody)
        {
            var dayId = incomingDayBody.DayId;
            _userPathDayInfo[dayId].WrittenWords = incomingDayBody.WrittenWords;
            _userWritingDayBodies[dayId] = incomingDayBody;
        }

        public void AccomplishDay(UserPathDayInfo day)
        {
            _userPathDayInfo[day.DayId].Accomplished = day.Accomplished;
            UnlockNextDay(day.DayId + 1);
        }
        private void UnlockNextDay(int ID)
        {
            _userPathDayInfo[ID].Locked = false;
        }

        public void ReceiveReward(WritingDayReward reward)
        {
            _writerProfile.ReceiveReward(reward);
        }

        public bool RewardReceived(int dayId)
        {
            return _writerProfile.RewardReceived(dayId);
        }
    }
}
