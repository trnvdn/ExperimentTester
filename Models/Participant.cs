namespace ExperimentTester.Models
{
    public class Participant
    {
        public Guid ParticipantID { get; set; }
        public Guid DeviceToken { get; set; }

        public ICollection<ExperimentParticipantAssociation> ExperimentParticipantAssociations { get; set; }
    }
}
