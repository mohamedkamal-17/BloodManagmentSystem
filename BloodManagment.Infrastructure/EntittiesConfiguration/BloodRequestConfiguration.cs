using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class BloodRequestConfiguration : IEntityTypeConfiguration<BloodRequest>
    {
        public void Configure(EntityTypeBuilder<BloodRequest> builder)
        {
            builder.Property(x => x.Reason).HasMaxLength(300);

            builder.HasOne(x => x.Hospital)
                .WithMany(x => x.BloodRequests)
                .HasForeignKey(x => x.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Rescipient)
                .WithMany(x => x.BloodRequests)
                .HasForeignKey(x => x.RescipientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.LabTechnician)
                .WithMany(x => x.BloodRequests)
                .HasForeignKey(x => x.LabTechnicianId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
