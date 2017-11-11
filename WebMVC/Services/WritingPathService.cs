using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using WebMVC.ViewModels;
using WebMVC.Interfaces;
using Infrastructure.Data;
using WebMVC.ViewModels.UserDTO;
using Infrastructure.Entities;

namespace WebMVC.Services
{
    public class WritingPathService : IWriterPathService
    {
        public IRepository<WritingPath> _writingPathRepository { get; set; }
        public IRepository<PathDayHeader> _writingDayHeadersRepository { get; set; }
        public IRepository<WritingDayReward> _inMemoryWritingRewardRepository { get; set; }
        public InMemoryUserDataRepository _inMemoryUserDataRepository { get; set; }

        private int CurrentWritingPath = 0;
        private string CurrentUser = "Thinkershine";

        public WritingPathService(IRepository<WritingPath> writingPathRepository,
            IRepository<PathDayHeader> writingDayHeaderRepository,
            IRepository<WritingDayReward> writingDayRewardReopsitory,
            InMemoryUserDataRepository userDataRepository)
        {
            _writingPathRepository = writingPathRepository;
            _writingDayHeadersRepository = writingDayHeaderRepository;
            _inMemoryUserDataRepository = userDataRepository;
            _inMemoryWritingRewardRepository = writingDayRewardReopsitory;
        }

        public Task<PathViewModel> GetWritingPathForUser()
        {
            var writingPath = _writingPathRepository.GetById(CurrentWritingPath);
            
            // TODO What if there is no writing path?
            // Create your own?

            return Task.Run(() => new PathViewModel
            {
                PathName = writingPath.PathName,
                TotalWords = writingPath.TotalWords,
                TotalDays = writingPath.TotalDays,
                DayHeaders = CreateDayHeaderViewModelsFromWritingPathDays(_writingDayHeadersRepository.List()),
                UserDays = CreateUserDayInfoViewModelForThisPath(_inMemoryUserDataRepository.GetUserPathDayInfo(CurrentUser)) //TODO: Load Only Unlocked Data?
                // TODO I will still need a way to filter results by pathID alone...
            });
        }

        private List<DayHeaderViewModel> CreateDayHeaderViewModelsFromWritingPathDays(List<PathDayHeader> dayHeaders)
        {
            List<DayHeaderViewModel> viewModel = new List<DayHeaderViewModel>();
            foreach(PathDayHeader day in dayHeaders)
            {
                viewModel.Add(new DayHeaderViewModel {
                    Id = day.Id,
                    DayNumber = day.VisibleDayNumber,
                    ExperienceReward = _inMemoryWritingRewardRepository.GetById(day.RewardId).Experience,
                    RequiredWords = day.RequiredWords,
                });
            }

            return viewModel;
        }
        private List<UserPathDayInfoViewModel> CreateUserDayInfoViewModelForThisPath(List<PathDayBody> userDataForPath)
        {
            List<UserPathDayInfoViewModel> userDataForView = new List<UserPathDayInfoViewModel>();
            foreach (PathDayBody day in userDataForPath)
            {
                userDataForView.Add(new UserPathDayInfoViewModel
                {
                    WrittenWords = day.WrittenWords,
                    Accomplished = day.Accomplished,
                    Locked = day.Locked
                });
            }
            return userDataForView;
        }

        public Task<IEnumerable<DayHeaderViewModel>> GetPathDayHeaders()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DayBodyViewModel>> GetPathDayBodies()
        {
            throw new System.NotImplementedException();
        }

        public Task<DayHeaderViewModel> GetPathDayHeader(int pathDay)
        {
            // todo: Get all days at the same time and enumerate??
            var pathDayModel = _writingDayHeadersRepository.GetById(pathDay);

            return Task.Run(() => new DayHeaderViewModel
            {
                Id = pathDayModel.Id,
                PathDayId = pathDayModel.PathDayId,
                DayNumber = pathDayModel.VisibleDayNumber,
                ExperienceReward = _inMemoryWritingRewardRepository.GetById(pathDayModel.RewardId).Experience,
                RequiredWords = pathDayModel.RequiredWords,
                WrittenWords = _inMemoryUserDataRepository.GetWrittenWordsForDay(pathDay, CurrentUser)
            });
        }

        public Task<DayBodyViewModel> GetPathDayBody(int pathDay)
        {
            var pathDayModel = _inMemoryUserDataRepository.GetUserWritingDayBodyById(pathDay, CurrentUser); // TODO : Get by Day ID not by ALL DAYS IDs...

            return Task.Run(() => new DayBodyViewModel
            {
                Id = pathDayModel.Id,
                DayId = pathDayModel.PathDayId,
                PathId = CurrentWritingPath,
                WrittenText = pathDayModel.WrittenText,
                WrittenWords = pathDayModel.WrittenWords
            });
        }

        public Task<string> GetQuoteOfTheDay(int dayId)
        {
            var pathDayModel = _writingDayHeadersRepository.GetById(dayId); // Todo: Get also by path...

            return Task.Run(() => pathDayModel.HiddenQuoteId); // unnecessarily taking all different informations... but hidden quote...
            // TODO: Hidden Quote Repository
        }

        public bool RewardReceived(int rewardId)
        {
            var rewardReceived = _inMemoryUserDataRepository.RewardReceived(rewardId, CurrentUser);
            return rewardReceived;
        }

        public Task<WritingDayReward> GetReward(int dayId)
        {
            return Task.Run(() => _inMemoryWritingRewardRepository.GetById(dayId));
        }
    }
}