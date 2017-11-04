using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using WebMVC.Interfaces;

namespace WebMVC.Services
{
    public class StorageService : IStorageService
    {
        private IRepository<WritingDayBody> _writingDayBodyRepository;

        public StorageService(IRepository<WritingDayBody> writingDayBodyRepository)
        {
            _writingDayBodyRepository = writingDayBodyRepository;
        }

        public void SaveTheDay(WritingDayBody incomingDayBody)
        {
            _writingDayBodyRepository.Update(incomingDayBody);
        }
    }
}