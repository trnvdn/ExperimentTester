using ExperimentTester.Models;

namespace ExperimentTester.Services.IServices
{
    public interface IExperimentHandlerService
    {
        Task<ExperimentResult> RunExperiment(Guid deviceToken, string xName);
    }
}
