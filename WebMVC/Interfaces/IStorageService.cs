using ApplicationCore.Entities;

namespace WebMVC.Interfaces
{
    public interface IStorageService
    {
        void SaveDay(UserDayBody incomingDayBody);
        void AccomplishDay(int dayID);
    }
}