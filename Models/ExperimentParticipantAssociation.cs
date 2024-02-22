namespace ExperimentTester.Models
{
    public class ExperimentParticipantAssociation
    {
        public Guid AssociationID { get; set; }
        public Guid ExperimentID { get; set; }
        public Guid ParticipantID { get; set; }
    }
}
