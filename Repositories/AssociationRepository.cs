using AutoMapper;
using ExperimentTester.DatabaseContext;
using ExperimentTester.Models;
using ExperimentTester.Repositories.IRepositories;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace ExperimentTester.Repositories
{
    public class AssociationRepository : IAssociationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AssociationRepository> _logger;
        public AssociationRepository(ApplicationDbContext context, ILogger<AssociationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> InsertAssociation(Guid participantId, Guid experimentId)
        {
            if(participantId != Guid.Empty && experimentId != Guid.Empty)
            {
                try
                {
                    await _context.ExperimentParticipantAssociations.AddAsync(new ExperimentParticipantAssociation
                    {
                        ExperimentID = experimentId,
                        ParticipantID = participantId
                    });

                    return await _context.SaveChangesAsync() > 0;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    return false;
                }
            }

            _logger.LogError("InsertAssociation -> ParticipantID or ExperimentID is empty");
            return false;
        }
    }
}
