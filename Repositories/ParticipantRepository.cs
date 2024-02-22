using ExperimentTester.Models.Dto;
using ExperimentTester.Repositories.IRepositories;

namespace ExperimentTester.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        public Task<bool> AddParticipantAsync(ParticipantDto participantDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<ParticipantDto>> GetAllParticipantsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ParticipantDto> GetParticipantByDeviceTokenAsync(Guid deviceToken)
        {
            throw new NotImplementedException();
        }

        public Task<ParticipantDto> GetParticipantByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
