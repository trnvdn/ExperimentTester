using ExperimentTester.Models.Dto;

namespace ExperimentTester.Repositories.IRepositories
{
    public interface IParticipantRepository
    {
        Task<List<ParticipantDto>> GetAllParticipantsAsync();
        Task<ParticipantDto> GetParticipantByIdAsync(Guid id);
        Task<bool> AddParticipantAsync(ParticipantDto participantDto);
        Task<ParticipantDto> GetParticipantByDeviceTokenAsync(Guid deviceToken);
    }
}
