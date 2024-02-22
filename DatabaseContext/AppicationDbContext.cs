using ExperimentTester.Models;
using Microsoft.EntityFrameworkCore;

namespace ExperimentTester.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<ExperimentParticipantAssociation> ExperimentParticipantAssociations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExperimentParticipantAssociation>()
                .HasKey(epa => epa.AssociationID); 

            modelBuilder.Entity<ExperimentParticipantAssociation>()
                .HasOne<Experiment>() 
                .WithMany(e => ExperimentParticipantAssociations) 
                .HasForeignKey(epa => epa.ExperimentID);

            modelBuilder.Entity<ExperimentParticipantAssociation>()
                .HasOne<Participant>() 
                .WithMany(p => ExperimentParticipantAssociations)
                .HasForeignKey(epa => epa.ParticipantID);
        }
    }
}
