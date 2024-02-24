using ExperimentTester.DatabaseContext;
using ExperimentTester.Models;
using ExperimentTester.Models.ViewModels;
using ExperimentTester.Services.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ExperimentTester.Services
{
    public class ExperimentsDetailsService : IExperimentsDetailsService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ExperimentsDetailsService> _logger;
        public ExperimentsDetailsService(ApplicationDbContext context, ILogger<ExperimentsDetailsService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<ExperimentDetails>> GetExperimentsDetailsAsync(string experimentKey)
        {
            try
            {
                var query = @"
                SELECT p.ParticipantId, p.DeviceToken, e.Value, e.DistributionPercentage
                FROM Participants p
                JOIN ExperimentParticipantAssociations a ON p.ParticipantId = a.ParticipantId
                JOIN Experiments e ON a.ExperimentId = e.ExperimentId AND e.[Key] = @ExperimentKey;";

                var result = await _context.ExperimentDetails
                    .FromSqlRaw(query, new SqlParameter("@ExperimentKey", experimentKey))
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{this.MemberwiseClone()} -> {ex.Message}");
                return new List<ExperimentDetails>();
            }
        }

        public void DeleteAllData()
        {
            try
            {
                _context.Database.ExecuteSqlRawAsync("DELETE FROM ExperimentParticipantAssociations");

                _context.Database.ExecuteSqlRawAsync("DELETE FROM Participants");

                _context.Database.ExecuteSqlRawAsync("DELETE FROM Experiments");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{this.GetType().Name} -> {ex.Message}");
            }
        }


    }
}
