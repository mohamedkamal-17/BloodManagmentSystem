using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class DonationHistoryConfiguration : IEntityTypeConfiguration<DonationHistory>
    {
        public void Configure(EntityTypeBuilder<DonationHistory> builder)
        {
            builder.Property(x => x.BloodGroup).HasConversion<string>();
            builder.Property(x => x.DonationLocation).HasMaxLength(200);
            builder.Property(x => x.Notes).HasMaxLength(500);


            builder.HasOne(x => x.Donor)
                .WithMany()
                .HasForeignKey(x => x.DonorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
