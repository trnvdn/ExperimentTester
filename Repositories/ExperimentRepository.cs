using AutoMapper;
using ExperimentTester.DatabaseContext;
using ExperimentTester.Models;
using ExperimentTester.Models.Dto;
using ExperimentTester.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ExperimentTester.Repositories
{
    public class ExperimentRepository : IExperimentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ExperimentRepository> _logger;
        public ExperimentRepository(ApplicationDbContext context, IMapper mapper, ILogger<ExperimentRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> AddExperimentAsync(ExperimentDto experimentDto)
        {
            if(experimentDto != null)
            {
                try
                {
                    await _context.Experiments.AddAsync(_mapper.Map<Experiment>(experimentDto));
                    return await _context.SaveChangesAsync() > 0;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{nameof(this.MemberwiseClone)} {ex.Message}");
                    return false;
                }
            }

            _logger.LogError($"{nameof(this.MemberwiseClone)} ExperimentDto is null");
            return false;
        }

        public async Task<List<ExperimentDto>> GetAllExperimentsAsync()
        {
            try
            {
                var experiments = await _context.Experiments.ToListAsync();

                return _mapper.Map<List<ExperimentDto>>(experiments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(this.MemberwiseClone)} {ex.Message}");
                return null;
            }
        }

        public async Task<ExperimentDto> GetExperimentByParticipantIdAndKeyAsync(Guid id, string key)
        {
            if(id != Guid.Empty && !string.IsNullOrEmpty(key))
            {
                try
                {
                    var association = await _context.ExperimentParticipantAssociations.Where(x => x.ParticipantID == id)
                    .Include(x => x.Experiment).FirstOrDefaultAsync(x => x.Experiment.Key == key);

                    if (association != null)
                    {
                        return _mapper.Map<ExperimentDto>(association.Experiment);
                    }

                    return null;
                }
                catch(Exception ex)
                {
                    _logger.LogError($"{nameof(this.MemberwiseClone)} {ex.Message}");
                    return null;
                }
            }
            
            _logger.LogError($"{nameof(this.MemberwiseClone)} ParticipantID or Key is null or empty");
            return null;
        }
    }
}
