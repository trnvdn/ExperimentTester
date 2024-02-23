using ExperimentTester.Models;
using ExperimentTester.Models.Dto;

namespace ExperimentTester.Services.IServices
{
    public interface IAssociationService
    {
        Task<bool> InsertAsync(Guid participantID, Guid experimentID);
        Task<List<ExperimentParticipantAssociationDto>> RetrieveAllAsync();
        Task<List<ExperimentParticipantAssociationDto>> RetrieveByParticipantAsync(Guid participantID);
        Task<ExperimentParticipantAssociationDto> RetrieveByExperimentAsync(Guid experimentID);
    }
}
