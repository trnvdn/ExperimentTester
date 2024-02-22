using ExperimentTester.Models.Dto;

namespace ExperimentTester.Repositories.IRepositories
{
    public interface IExperimentRepository
    {
        Task<List<ExperimentDto>> GetAllExperimentsAsync();
        Task<ExperimentDto> GetExperimentByParticipantIdAndKeyAsync(Guid id, string key);
        Task<bool> AddExperimentAsync(ExperimentDto experimentDto);
    }
}
