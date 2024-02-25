using ExperimentTester.Models.Dto;
using ExperimentTester.Repositories.IRepositories;
using ExperimentTester.Services.IServices;

namespace ExperimentTester.Services
{
    public class AssociationService : IAssociationService
    {
        private readonly IAssociationRepository _associationRepository;
        public AssociationService(IAssociationRepository associationRepository)
        {
            _associationRepository = associationRepository;
        }

        public async Task<bool> InsertAsync(Guid participantID, Guid experimentID)
        {
            return await _associationRepository.InsertAssociation(participantID, experimentID);
        }

        public async Task<ExperimentParticipantAssociationDto> RetrieveByExperimentAsync(Guid experimentID)
        {
            return await _associationRepository.RetrieveByExperimentAsync(experimentID);
        }

        public async Task<List<ExperimentParticipantAssociationDto>> RetrieveByParticipantAsync(Guid participantID)
        {
            return await _associationRepository.RetrieveByParticipantAsync(participantID);
        }

        public async Task<List<ExperimentParticipantAssociationDto>> RetrieveAllAsync()
        {
            return await _associationRepository.RetrieveAllAsync();
        }
    }
}
