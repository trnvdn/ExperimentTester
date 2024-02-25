using AutoMapper;
using ExperimentTester.DatabaseContext;
using ExperimentTester.Models;
using ExperimentTester.Models.Dto;
using ExperimentTester.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ExperimentTester.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<ParticipantRepository> _logger;
        public ParticipantRepository(ApplicationDbContext context, IMapper mapper, ILogger<ParticipantRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> AddParticipantAsync(ParticipantDto participantDto)
        {
            try
            {
                await _context.Participants.AddAsync(_mapper.Map<Participant>(participantDto));
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(this.MemberwiseClone)} {ex.Message}");
                return false;
            }
            
        }

        public async Task<List<ParticipantDto>> GetAllParticipantsAsync()
        {
            try
            {
                var participants = await _context.Participants.ToListAsync();

                return _mapper.Map<List<ParticipantDto>>(participants);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(this.MemberwiseClone)} {ex.Message}");
                return null;
            }
        }

        public async Task<ParticipantDto> GetParticipantByDeviceTokenAsync(Guid deviceToken)
        {
            if(deviceToken != Guid.Empty)
            {
                try
                {
                    var participant = await _context.Participants.FirstOrDefaultAsync(x => x.DeviceToken == deviceToken);
                    return _mapper.Map<ParticipantDto>(participant);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{nameof(this.MemberwiseClone)} {ex.Message}");
                    return null;
                }
            }

            _logger.LogError($"{nameof(this.MemberwiseClone)} DeviceToken is empty");
            return null;
        }

        public async Task<ParticipantDto> GetParticipantByIdAsync(Guid id)
        {
            if (id != Guid.Empty)
            {
                var participant = await _context.Participants.FirstOrDefaultAsync(x => x.ParticipantID == id);
                return _mapper.Map<ParticipantDto>(participant);
            }

            _logger.LogError($"{nameof(this.MemberwiseClone)} DeviceToken is empty");
            return null;
        }
    }
}
