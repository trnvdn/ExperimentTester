using ExperimentTester.DatabaseContext;
using ExperimentTester.Models;
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

        /*Since I can guarantee that in each experiment 1 device 
        can take part only once, all you need to do is
        A) Divide all experiments by their names
        B) Divide the received experiments according to answer options
        C) Calculate metrics*/
        public List<DeviceTokenDistribution> DeviceTokenDistribution()
        {
            var result = new List<DeviceTokenDistribution>();

            try
            {
                var experimentsByValueCount = getDividedExperimentsByKeyAndValue();
                foreach (var kvp in experimentsByValueCount)
                {
                    var experimentName = kvp.Key;
                    var totalCount = _context.Experiments.Where(x => x.Key == experimentName).Count();

                    foreach (var subKvp in kvp.Value)
                    {
                        var option = subKvp.Key;
                        var percentage = subKvp.Value / (double)totalCount * 100;

                        var deviceTokenDistribution = new DeviceTokenDistribution
                        {
                            ExperimentName = experimentName,
                            Option = option,
                            OptionDistribution = subKvp.Value,
                            DistributionPercentage = Math.Round(percentage, 2)
                        };
                        result.Add(deviceTokenDistribution);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{this.MemberwiseClone()} -> {ex.Message}");
                return new List<DeviceTokenDistribution>();
            }
        }

        private Dictionary<string, Dictionary<string?, int>> getDividedExperimentsByKeyAndValue()
        {
            var experimentsByValue = _context.Experiments.GroupBy(x => x.Key).ToDictionary(
                group => group.Key,
                group => group.GroupBy(x => x.Value).ToDictionary(
                        subGroup => subGroup.Key,
                        subGroup => subGroup.ToList()
                    )
            );
            var experimentsByValueCount = experimentsByValue.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.ToDictionary(
                        subKvp => subKvp.Key,
                        subKvp => subKvp.Value.Count
                    )
            );
            return experimentsByValueCount;
        }

        public void DeleteAllData()
        {
            try
            {
                _context.Database.ExecuteSqlRaw("DELETE FROM ExperimentParticipantAssociations");

                _context.Database.ExecuteSqlRaw("DELETE FROM Participants");

                _context.Database.ExecuteSqlRaw("DELETE FROM Experiments");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{GetType().Name} -> {ex.Message}");
            }
        }


    }
}
