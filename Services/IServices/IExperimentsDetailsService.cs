using ExperimentTester.Models;

namespace ExperimentTester.Services.IServices
{
    public interface IExperimentsDetailsService
    {
        Task<List<ExperimentDetails>> GetExperimentsDetailsAsync(string xName);
        List<DeviceTokenDistribution> DeviceTokenDistribution();
        void DeleteAllData();
    }
}
