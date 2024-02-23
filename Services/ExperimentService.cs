using ExperimentTester.Models.Dto;
using ExperimentTester.Repositories.IRepositories;
using ExperimentTester.Services.IServices;

namespace ExperimentTester.Services
{
    public class ExperimentService : IExperimentService
    {
        private readonly IExperimentRepository _experimentRepository;
        public ExperimentService(IExperimentRepository experimentRepository)
        {
            _experimentRepository = experimentRepository;
        }

        public async Task<bool> AddExperimentAsync(ExperimentDto model)
        {
            return await _experimentRepository.AddExperimentAsync(model);
        }

        public async Task<List<ExperimentDto>> GetAllExperimentsAsync()
        {
            return await _experimentRepository.GetAllExperimentsAsync();
        }

        public async Task<ExperimentDto> GetExperimentByParticipantIdAndKeyAsync(Guid id, string key)
        {
            return await _experimentRepository.GetExperimentByParticipantIdAndKeyAsync(id, key);
        }
    }
}
