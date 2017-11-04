using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace WebMVC.Interfaces
{
    public interface IStorageService
    {
        void SaveTheDay(UserWritingDayBody incomingDayBody);
    }
}
