﻿using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using WritingWeb.ViewModels;

namespace WritingWeb.Interfaces
{
    public interface IWriterPathService
    {
        Task<PathViewModel> GetWritingPathForUser();
        Task<IEnumerable<DayHeaderViewModel>> GetPathDayHeaders();
        Task<IEnumerable<DayBodyViewModel>> GetPathDayBodies();
        Task<DayHeaderViewModel> GetPathDayHeader(int pathDay);
        Task<DayBodyViewModel> GetPathDayBody(int pathDay);
        Task<string> GetQuoteOfTheDay(int dayId);
        bool RewardReceived(int rewardId);
        Task<WritingDayReward> GetReward(int dayId);
    }
}