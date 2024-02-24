using ExperimentTester.Models;

namespace ExperimentTester.Services.IServices
{
    public interface IExperimentHandlerService
    {
        Task<List<ExperimentResult>> RunExperiment(string xName, Guid deviceToken);
        Task<List<ExperimentResult>> RunExperiments(string xName, int count);
    }
}
