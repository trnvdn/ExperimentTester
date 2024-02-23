using ExperimentTester.DatabaseContext;
using ExperimentTester.Models.Dto;
using ExperimentTester.Repositories.IRepositories;
using ExperimentTester.Services.IServices;

namespace ExperimentTester.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        public ParticipantService(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task<bool> AddParticipantAsync(ParticipantDto participantDto)
        {
            return await _participantRepository.AddParticipantAsync(participantDto);
        }

        public async Task<List<ParticipantDto>> GetAllParticipantsAsync()
        {
            return await _participantRepository.GetAllParticipantsAsync();
        }

        public async Task<ParticipantDto> GetParticipantByDeviceTokenAsync(Guid deviceToken)
        {
            return await _participantRepository.GetParticipantByDeviceTokenAsync(deviceToken);
        }

        public async Task<ParticipantDto> GetParticipantByIdAsync(Guid id)
        {
            return await _participantRepository.GetParticipantByIdAsync(id);
        }
    }
}
