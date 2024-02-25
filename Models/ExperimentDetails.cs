namespace ExperimentTester.Models
{
    public class ExperimentDetails
    {
        public Guid ParticipantID { get; set; }
        public Guid DeviceToken { get; set; }
        public string? Value { get; set; }
        public int DistributionPercentage { get; set; }
    }
}
