using ApplicationCore.Entities;
using Infrastructure.Data;
using WritingWeb.Interfaces;

namespace WritingWeb.Services
{
    public class StorageService : IStorageService
    {
        private InMemoryUserDataRepository _writingUserDayBodyRepository;

        public StorageService(InMemoryUserDataRepository writingUserDayBodyRepository)
        {
            _writingUserDayBodyRepository = writingUserDayBodyRepository;
        }

        public void SaveDay(UserDayBody incomingDayBody)
        {
            _writingUserDayBodyRepository.UpdateUserWritingDay(incomingDayBody, "Thinkershine");
        }

        public void AccomplishDay(int dayID)
        {
            _writingUserDayBodyRepository.AccomplishDay(dayID, "Thinkershine");
        }
    }
}