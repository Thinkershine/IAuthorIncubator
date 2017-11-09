using ApplicationCore.Entities;
using Infrastructure.Data;
using WebMVC.Interfaces;

namespace WebMVC.Services
{
    public class StorageService : IStorageService
    {
        private InMemoryUserDataRepository _writingUserDayBodyRepository;

        public StorageService(InMemoryUserDataRepository writingUserDayBodyRepository)
        {
            _writingUserDayBodyRepository = writingUserDayBodyRepository;
        }

        public void SaveDay(UserWritingDayBody incomingDayBody)
        {
            _writingUserDayBodyRepository.UpdateUserWritingDay(incomingDayBody, "Thinkershine");
        }

        public void AccomplishDay(UserPathDayInfo incomingAccomplishedDay)
        {
            _writingUserDayBodyRepository.AccomplishDay(incomingAccomplishedDay, "Thinkershine");
        }
    }
}