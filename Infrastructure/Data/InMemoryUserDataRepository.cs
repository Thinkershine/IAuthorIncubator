using ApplicationCore.Entities;
using Infrastructure.Entities;
using Infrastructure.UserData;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryUserDataRepository
    {
        private Dictionary<string, User> Users { get; set; }

        public InMemoryUserDataRepository()
        {
            Users = new Dictionary<string, User>();
            Users.Add("Thinkershine", new User());
        }

        public WriterProfile GetUserWriterProfile(string userName)
        {
            return Users[userName].GetWriterProfile();
        }

        public List<PathDayBody> GetUserPathDayInfo(string userName)
        {
            return Users[userName].GetUserPathDayInfo();
        }

        public int GetWrittenWordsForDay(int dayID, string userName)
        {
            return Users[userName].GetWrittenWordsForDay(dayID);
        }

        public UserDayBody GetUserWritingDayBodyById(int dayID, string userName)
        {
            return Users[userName].GetWritingDayBody(dayID);
        }

        public void UpdateUserWritingDay(UserDayBody incomingDayBody, string userName)
        {
            Users[userName].UpdateUserWritingDay(incomingDayBody);
        }

        public void AccomplishDay(int dayID, string userName)
        {
            Users[userName].AccomplishDay(dayID);
        }

        public void ReceiveReward(WritingDayReward reward, string userName)
        {
            Users[userName].ReceiveReward(reward);
        }

        public bool RewardReceived(int dayID, string userName)
        {
            return Users[userName].RewardReceived(dayID);
        }
    }
}