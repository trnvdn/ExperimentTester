namespace ExperimentTester.Models.Dto
{
    public class ExperimentParticipantAssociationDto
    {
        public Guid AssociationID { get; set; }
        public Guid ExperimentID { get; set; }
        public Guid ParticipantID { get; set; }
    }
}
