using ExperimentTester.Models.Dto;

namespace ExperimentTester.Services.IServices
{
    public interface IParticipantService
    {
        Task<bool> AddParticipantAsync(ParticipantDto participantDto);
        Task<List<ParticipantDto>> GetAllParticipantsAsync();
        Task<ParticipantDto> GetParticipantByDeviceTokenAsync(Guid deviceToken);
        Task<ParticipantDto> GetParticipantByIdAsync(Guid id);
    }
}
