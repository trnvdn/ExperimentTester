namespace ExperimentTester.Models
{
    public class Experiment
    {
        public Guid ExperimentId { get; set; }
        public string Key { get; set; }
        public string? Value { get; set; }
        public int DistributionPercentage { get; set; }
    }
}
