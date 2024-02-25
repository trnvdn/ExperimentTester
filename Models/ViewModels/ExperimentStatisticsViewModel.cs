namespace ExperimentTester.Models.ViewModels
{
    public class ExperimentStatisticsViewModel
    {
        public List<ExperimentDetails> ButtonExperiment { get; set; }
        public List<ExperimentDetails> PriceExperiment { get; set; }
        public List<DeviceTokenDistribution> DistributionStats { get; set; }
    }
}
