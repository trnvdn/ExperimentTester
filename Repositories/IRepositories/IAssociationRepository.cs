namespace ExperimentTester.Repositories.IRepositories
{
    public interface IAssociationRepository
    {
        Task<bool> InsertAssociation(Guid participantId, Guid experimentId);
    }
}
