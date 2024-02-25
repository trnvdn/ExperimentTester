using ExperimentTester.Models;
using ExperimentTester.Models.ViewModels;

namespace ExperimentTester.Services.IServices
{
    public interface IExperimentsDetailsService
    {
        Task<List<ExperimentDetails>> GetExperimentsDetailsAsync(string xName);
        List<DeviceTokenDistribution> DeviceTokenDistribution();
        void DeleteAllData();
    }
}
