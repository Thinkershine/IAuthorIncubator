using ApplicationCore.Entities;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class InMemoryUserDataRepository
    {
        private List<UserPathDayInfo> _userPathDayInfo { get; }

        public InMemoryUserDataRepository()
        {
            _userPathDayInfo = new List<UserPathDayInfo>();
            InitializeUserPathDayInfo();
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

        public List<UserPathDayInfo> GetUserPathDayInfo()
        {
            return _userPathDayInfo;
        }
    }
}
