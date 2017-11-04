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

        public void SaveTheDay(UserWritingDayBody incomingDayBody)
        {
            _writingUserDayBodyRepository.UpdateUserWritingDayBodyForId(incomingDayBody);
        }
    }
}