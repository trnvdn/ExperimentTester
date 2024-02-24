using AutoMapper;
using ExperimentTester.DatabaseContext;
using ExperimentTester.Models;
using ExperimentTester.Models.Dto;
using ExperimentTester.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ExperimentTester.Repositories
{
    public class AssociationRepository : IAssociationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AssociationRepository> _logger;
        public AssociationRepository(ApplicationDbContext context, IMapper mapper ,ILogger<AssociationRepository> logger)
        {
            _context = context;
            _mapper = mapper;
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
                    _logger.LogError($"{nameof(this.MemberwiseClone)} {ex.Message}");
                    return false;
                }
            }

            _logger.LogError($"{nameof(this.MemberwiseClone)} ParticipantID or ExperimentID is empty");
            return false;
        }

        public async Task<List<ExperimentParticipantAssociationDto>> RetrieveAllAsync()
        {
            try
            {
                var associations = await _context.ExperimentParticipantAssociations.ToListAsync();

                return _mapper.Map<List<ExperimentParticipantAssociationDto>>(associations);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(this.MemberwiseClone)} {ex.Message}");
                return null;
            }
        }

        public async Task<List<ExperimentParticipantAssociationDto>> RetrieveByParticipantAsync(Guid participantID)
        {
            if(participantID != Guid.Empty)
            {
                try
                {
                    var participant = await _context.ExperimentParticipantAssociations.Where(x => x.ParticipantID == participantID).ToListAsync();
                    return _mapper.Map<List<ExperimentParticipantAssociationDto>>(participant);
                }
                catch(Exception ex)
                {
                    _logger.LogError($"{nameof(this.MemberwiseClone)} {ex.Message}");
                    return null;
                }
            }

            _logger.LogError($"{nameof(this.MemberwiseClone)} ParticipantID is empty");
            return null;
        }
        public async Task<ExperimentParticipantAssociationDto> RetrieveByExperimentAsync(Guid experimentID)
        {
            if(experimentID != Guid.Empty)
            {
                var experiment = await _context.ExperimentParticipantAssociations.FirstOrDefaultAsync(x => x.ExperimentID == experimentID);
                return _mapper.Map<ExperimentParticipantAssociationDto>(experiment);
            }

            _logger.LogError($"{nameof(this.MemberwiseClone)} ExperimentID is empty");
            return null;
        }
    }
}
