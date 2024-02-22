using ExperimentTester.Repositories.IRepositories;

namespace ExperimentTester.Repositories
{
    public class AssociationRepository : IAssociationRepository
    {
        public Task<bool> InsertAssociation(Guid participantId, Guid experimentId)
        {
            throw new NotImplementedException();
        }
    }
}
