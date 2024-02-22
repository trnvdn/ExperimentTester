using ExperimentTester.Models.Dto;
using ExperimentTester.Repositories.IRepositories;

namespace ExperimentTester.Repositories
{
    public class ExperimentRepository : IExperimentRepository
    {
        public Task<bool> AddExperimentAsync(ExperimentDto experimentDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExperimentDto>> GetAllExperimentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ExperimentDto> GetExperimentByParticipantIdAndKeyAsync(Guid id, string key)
        {
            throw new NotImplementedException();
        }
    }
}
