using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using WebMVC.ViewModels;
using WebMVC.Interfaces;
using Infrastructure.Data;
using WebMVC.ViewModels.UserDTO;
using Infrastructure.Entities;
using Infrastructure.UserData;

namespace WebMVC.Services
{
    public class WritingPathService : IWriterPathService
    {
        public IRepository<WritingPath> _writingPathRepository { get; set; }
        public IRepository<WritingDayHeader> _writingDayHeadersRepository { get; set; }
        public InMemoryUserDataRepository _inMemoryUserDataRepository { get; set; }
        public IRepository<WritingDayReward> _inMemoryWritingRewardRepository { get; set; }


        public WritingPathService(IRepository<WritingPath> writingPathRepository,
            IRepository<WritingDayHeader> writingDayHeaderRepository,
            InMemoryUserDataRepository userDataRepository,
            IRepository<WritingDayReward> writingDayRewardReopsitory)
        {
            _writingPathRepository = writingPathRepository;
            _writingDayHeadersRepository = writingDayHeaderRepository;
            _inMemoryUserDataRepository = userDataRepository;
            _inMemoryWritingRewardRepository = writingDayRewardReopsitory;
        }

        public Task<WritingPathViewModel> GetWritingPathForUser(int pathId, string userName)
        {
            var writingPath = _writingPathRepository.GetById(pathId);
            
            // TODO What if there is no writing path?
            // Create your own?

            return Task.Run(() => new WritingPathViewModel
            {
                Id = writingPath.Id,
                PathName = writingPath.PathName,
                TotalWords = writingPath.TotalWords,
                TotalDays = writingPath.TotalDays,
                Days = CreateDayHeaderViewModelsFromWritingPathDays(_writingDayHeadersRepository.List()),
                UserDays = CreateUserDayInfoViewModelForThisPath(_inMemoryUserDataRepository.GetUserPathDayInfo())
                // TODO I will still need a way to filter results by pathID alone...
            });
        }

        private List<WritingDayHeaderViewModel> CreateDayHeaderViewModelsFromWritingPathDays(List<WritingDayHeader> dayHeaders)
        {
            List<WritingDayHeaderViewModel> viewModel = new List<WritingDayHeaderViewModel>();
            foreach(WritingDayHeader day in dayHeaders)
            {
                viewModel.Add(new WritingDayHeaderViewModel {
                    Id = day.Id,
                    DayId = day.DayId,
                    DayNumber = day.DayNumber,
                    ExperienceReward = day.ExperienceReward,
                    RequiredWords = day.RequiredWords,
                });
            }

            return viewModel;
        }
        private List<UserPathDayInfoViewModel> CreateUserDayInfoViewModelForThisPath(List<UserPathDayInfo> userDataForPath)
        {
            List<UserPathDayInfoViewModel> userDataForView = new List<UserPathDayInfoViewModel>();
            foreach (UserPathDayInfo day in userDataForPath)
            {
                userDataForView.Add(new UserPathDayInfoViewModel
                {
                    PathId = day.PathId,
                    DayId = day.DayId,
                    WrittenWords = day.WrittenWords,
                    Accomplished = day.Accomplished,
                    Locked = day.Locked
                });
            }
            return userDataForView;
        }

        public Task<IEnumerable<WritingDayHeaderViewModel>> GetPathDayHeaders(int pathId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<WritingDayBodyViewModel>> GetPathDayBodies(int pathId)
        {
            throw new System.NotImplementedException();
        }

        public Task<WritingDayHeaderViewModel> GetPathDayHeader(int pathId, int pathDay, string userName)
        {
            var pathDayModel = _writingDayHeadersRepository.GetById(pathDay);

            return Task.Run(() => new WritingDayHeaderViewModel
            {
                Id = pathDayModel.Id,
                DayNumber = pathDayModel.DayNumber,
                ExperienceReward = pathDayModel.ExperienceReward,
                RequiredWords = pathDayModel.RequiredWords,
                WrittenWords = _inMemoryUserDataRepository.GetWrittenWordsForDay(pathDay)
            });
        }

        public Task<WritingDayBodyViewModel> GetPathDayBody(int pathId, int pathDay, string userName)
        {
            var pathDayModel = _inMemoryUserDataRepository.GetUserWritingDayBodyById(pathDay); // TODO : Get by Day ID not by ALL DAYS IDs...

            return Task.Run(() => new WritingDayBodyViewModel
            {
                Id = pathDayModel.Id,
                DayId = pathDayModel.DayId,
                PathId = pathId,
                WrittenText = pathDayModel.WrittenText,
                WrittenWords = pathDayModel.WrittenWords
            });
        }

        public Task<string> GetQuoteOfTheDay(int pathId, int dayId)
        {
            var pathDayModel = _writingDayHeadersRepository.GetById(dayId); // Todo: Get also by path...

            return Task.Run(() => pathDayModel.HiddenQuote);
        }

        public bool RewardReceived(int rewardId)
        {
            var rewardReceived = _inMemoryUserDataRepository.RewardReceived(rewardId);
            return rewardReceived;
        }

        public Task<WritingDayReward> GetReward(int pathId, int dayId)
        {
            return Task.Run(() => _inMemoryWritingRewardRepository.GetById(dayId));
        }
    }
}