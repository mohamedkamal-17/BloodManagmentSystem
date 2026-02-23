using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.ContactNumber).HasMaxLength(50);

            builder.HasMany(x => x.LabTechnicians)
                .WithOne(x => x.Hospital)
                .HasForeignKey(x => x.HospitalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.BloodInventories)
                .WithOne(x => x.Hospital)
                .HasForeignKey(x => x.HospitalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.BloodRequests)
                .WithOne(x => x.Hospital)
                .HasForeignKey(x => x.HospitalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
