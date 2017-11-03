using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using WebMVC.ViewModels;

namespace WebMVC.Services
{
    public class WritingPathService : IWriterPathService
    {
        public IRepository<WritingPath> _writingPathRepository { get; set; }
        public IRepository<WritingDayHeader> _writingDayHeadersRepository { get; set; }
        public IRepository<WritingDayBody> _writingDayBodiesRepository { get; set; }

        public WritingPathService(IRepository<WritingPath> writingPathRepository,
            IRepository<WritingDayHeader> writingDayHeaderRepository,
            IRepository<WritingDayBody> writingDayBodyRepository)
        {
            _writingPathRepository = writingPathRepository;
            _writingDayHeadersRepository = writingDayHeaderRepository;
            _writingDayBodiesRepository = writingDayBodyRepository;
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
                Days = CreateDayHeaderViewModelsFromWritingPathDays(_writingDayHeadersRepository.List())
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
                    DayNumber = day.DayNumber,
                    HiddenQuote = day.HiddenQuote,
                    ExperienceReward = day.ExperienceReward,
                    RequiredWords = day.RequiredWords,
                    WrittenWords = day.WrittenWords
                });
            }

            return viewModel;
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
                GoldenPenReward = pathDayModel.GoldenPenReward,
                RequiredWords = pathDayModel.RequiredWords,
                WrittenWords = pathDayModel.WrittenWords
            });
        }

        public Task<WritingDayBodyViewModel> GetPathDayBody(int pathId, int pathDay, string userName)
        {
            var pathDayModel = _writingDayBodiesRepository.GetById(pathDay); // TODO : Get by Day ID not by ALL DAYS IDs...

            return Task.Run(() => new WritingDayBodyViewModel
            {
                Id = pathDayModel.Id,
                PathId = pathId,
                WrittenText = pathDayModel.WrittenText,
                HiddenWisdom = pathDayModel.HiddenWisdom,
                ExercisePrompts = pathDayModel.ExercisePrompts
            });
        }

        public Task<string> GetQuoteOfTheDay(int pathId, int dayId)
        {
            var pathDayModel = _writingDayHeadersRepository.GetById(dayId); // Todo: Get also by path...

            return Task.Run(() => pathDayModel.HiddenQuote);
        }
    }
}