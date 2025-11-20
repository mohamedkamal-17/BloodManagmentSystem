using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class AnemiaBloodRequestConfiguration : IEntityTypeConfiguration<AnemiaBloodRequest>
    {
        public void Configure(EntityTypeBuilder<AnemiaBloodRequest> builder)
        {
            builder.HasKey(x => x.RequestCode);

            builder.Property(x => x.ResponsibleEntity).HasMaxLength(200).IsRequired();
            builder.Property(x => x.BloodTestIssuer).HasMaxLength(200);
            builder.Property(x => x.BloodGroup).HasConversion<string>();
            builder.Property(x => x.Status).HasConversion<string>();

            builder.HasOne(x => x.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
