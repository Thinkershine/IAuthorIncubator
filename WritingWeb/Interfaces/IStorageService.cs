using ApplicationCore.Entities;

namespace WritingWeb.Interfaces
{
    public interface IStorageService
    {
        void SaveDay(UserDayBody incomingDayBody);
        void AccomplishDay(int dayID);
    }
}