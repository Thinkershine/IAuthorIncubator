﻿using ApplicationCore.Entities;
using System.Collections.Generic;

namespace Infrastructure.UserData
{
    public class User
    {
        private List<PathDayBody> _userPathDayInfo { get; }
        private List<UserDayBody> _userWritingDayBodies { get; }
        private WriterProfile _writerProfile { get; }

        public User()
        {
            _userPathDayInfo = new List<PathDayBody>();
            _userWritingDayBodies = new List<UserDayBody>();
            _writerProfile = new WriterProfile();

            InitializeUserPathDayInfo();
            InitializeUserWritingDayBodies();
        }

        private void InitializeUserPathDayInfo()
        {
            for (int i = 0; i < 30; i += 1)
            {
                _userPathDayInfo.Add(new PathDayBody
                {
                    WritingPathID = 0,
                    PathDayBodyID = i,
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

        private UserDayBody GetEmptyWritingDayBody(int ID, int dayID, int pathID)
        {
            return new UserDayBody
            {
                UserDayBodyID = ID,
                PathDayNumber = dayID,
                WritingPathID = pathID,
                WrittenText = string.Empty,
                WrittenWords = 0
            };
        }

        public WriterProfile GetWriterProfile()
        {
            return _writerProfile;
        }

        public List<PathDayBody> GetUserPathDayInfo()
        {
            return _userPathDayInfo;
        }

        public int GetWrittenWordsForDay(int dayID)
        {
            return _userPathDayInfo[dayID].WrittenWords;
        }

        public UserDayBody GetWritingDayBody(int dayID)
        {
            return _userWritingDayBodies[dayID];
        }

        public void UpdateUserWritingDay(UserDayBody incomingDayBody)
        {
            var dayId = incomingDayBody.UserDayBodyID;
            _userPathDayInfo[dayId].WrittenWords = incomingDayBody.WrittenWords;
            _userWritingDayBodies[dayId] = incomingDayBody;
        }

        public void AccomplishDay(int dayID)
        {
            _userPathDayInfo[dayID].Accomplished = true;
            UnlockNextDay(dayID + 1);
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
