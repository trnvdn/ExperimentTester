namespace ExperimentTester.Models
{
    public class Experiment
    {
        public Guid ExperimentID { get; set; }
        public string Key { get; set; }
        public string? Value { get; set; }
        public int DistributionPercentage { get; set; }

        public ICollection<ExperimentParticipantAssociation> ExperimentParticipantAssociations { get; set; }
    }
}
