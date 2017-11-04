using ApplicationCore.Entities;

namespace WebMVC.Interfaces
{
    public interface IStorageService
    {
        void SaveTheDay(UserWritingDayBody incomingDayBody);
        void AccomplishTheDay(UserPathDayInfo accomplishedDay);
    }
}