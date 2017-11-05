using ApplicationCore.Entities;

namespace WebMVC.Interfaces
{
    public interface IStorageService
    {
        void SaveDay(UserWritingDayBody incomingDayBody);
        void AccomplishDay(UserPathDayInfo accomplishedDay);
    }
}