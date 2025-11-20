
using BloodManagment.domain.Entities;
using BloodManagment.Infrastructure.Extension;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloodManagment.Infrastructure.DataHelper
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyGlobalConfigurations();

        }

        // ==================== Blood & Requests ====================
        public DbSet<BloodUnit> BloodUnits { get; set; }
        public DbSet<BloodInventory> BloodInventories { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<RecipientBloodRequestHistory> RecipientBloodRequests { get; set; }
        public DbSet<AnemiaBloodRequest> AnemiaBloodRequests { get; set; }

        // ==================== Donation ====================
        public DbSet<Donar> Donars { get; set; }
        public DbSet<DonationHistory> DonationHistories { get; set; }
        public DbSet<DonationRequest> DonationRequests { get; set; }
        public DbSet<HealthCondition> HealthConditions { get; set; }

        // ==================== People ====================
        public DbSet<Rescipient> Rescipients { get; set; }
        public DbSet<ThalassemiaPatient> ThalassemiaPatients { get; set; }
        public DbSet<ThalassemiaPatientDonorAssignement> ThalassemiaPatientDonorAssignements { get; set; }
        public DbSet<LabTechnician> LabTechnicians { get; set; }

        // ==================== Hospital ====================
        public DbSet<Hospital> Hospitals { get; set; }

        // ==================== Notifications ====================
        public DbSet<Notification> Notifications { get; set; }



    }
}


