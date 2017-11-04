using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using WebMVC.Interfaces;

namespace WebMVC.Services
{
    public class StorageService : IStorageService
    {
        private IRepository<UserWritingDayBody> _writingDayBodyRepository;

        public StorageService(IRepository<UserWritingDayBody> writingDayBodyRepository)
        {
            _writingDayBodyRepository = writingDayBodyRepository;
        }

        public void SaveTheDay(UserWritingDayBody incomingDayBody)
        {
            _writingDayBodyRepository.Update(incomingDayBody);
        }
    }
}