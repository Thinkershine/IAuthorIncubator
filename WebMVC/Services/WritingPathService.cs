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

        public WritingPathService(IRepository<WritingPath> writingPathRepository,
            IRepository<WritingDayHeader> writingDayHeaderRepository)
        {
            _writingPathRepository = writingPathRepository;
            _writingDayHeadersRepository = writingDayHeaderRepository;
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
            throw new System.NotImplementedException();
        }

        public Task<WritingDayBodyViewModel> GetPathDayBody(int pathId, int pathDay, string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}