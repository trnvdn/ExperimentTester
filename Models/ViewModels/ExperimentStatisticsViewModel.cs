namespace ExperimentTester.Models.ViewModels
{
    public class ExperimentStatisticsViewModel
    {
        public Guid ParticipantID { get; set; }
        public Guid DeviceToken { get; set; }
        public string? Value { get; set; }
        public string? DistributionPercentage { get; set; }
    }
}
