using Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.ViewModels;

namespace WebMVC.Interfaces
{
    public interface IWriterPathService
    {
        Task<WritingPathViewModel> GetWritingPathForUser(int pathId, string userName);
        Task<IEnumerable<WritingDayHeaderViewModel>> GetPathDayHeaders(int pathId);
        Task<IEnumerable<WritingDayBodyViewModel>> GetPathDayBodies(int pathId);
        Task<WritingDayHeaderViewModel> GetPathDayHeader(int pathId, int pathDay, string userName);
        Task<WritingDayBodyViewModel> GetPathDayBody(int pathId, int pathDay, string userName);
        Task<string> GetQuoteOfTheDay(int pathId, int dayId);
        bool RewardReceived(int rewardId);
        Task<WritingDayReward> GetReward(int pathId, int dayId);
    }
}