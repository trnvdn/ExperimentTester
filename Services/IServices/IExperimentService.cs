using ExperimentTester.Models.Dto;

namespace ExperimentTester.Services.IServices
{
    public interface IExperimentService
    {
        Task<bool> AddExperimentAsync(ExperimentDto model);
        Task<ExperimentDto> GetExperimentByParticipantIdAndKeyAsync(Guid id, string key);
        Task<List<ExperimentDto>> GetAllExperimentsAsync();
    }
}
