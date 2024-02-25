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
        public DbSet<ExperimentDetails> ExperimentDetails { get; set; }
        public DbSet<DeviceTokenDistribution> DeviceTokenDistributions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExperimentDetails>().HasNoKey();
            modelBuilder.Entity<DeviceTokenDistribution>().HasNoKey();

            modelBuilder.Entity<ExperimentParticipantAssociation>()
                .HasKey(epa => epa.AssociationID);

            modelBuilder.Entity<ExperimentParticipantAssociation>()
                .HasOne(epa => epa.Experiment) 
                .WithMany(e => e.ExperimentParticipantAssociations) 
                .HasForeignKey(epa => epa.ExperimentID);

            modelBuilder.Entity<ExperimentParticipantAssociation>()
                .HasOne(epa => epa.Participant) 
                .WithMany(p => p.ExperimentParticipantAssociations) 
                .HasForeignKey(epa => epa.ParticipantID);
        }
    }
}
