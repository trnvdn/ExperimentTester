namespace ExperimentTester.Models.Dto
{
    public class ExperimentDto
    {
        public Guid ExperimentID { get; set; }
        public string Key { get; set; }
        public string? Value { get; set; }
        public int DistributionPercentage { get; set; }
    }
}
