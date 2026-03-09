using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class DonationRequestConfiguration : IEntityTypeConfiguration<DonationRequest>
    {
        public void Configure(EntityTypeBuilder<DonationRequest> builder)
        {
            builder.Property(x => x.RequestCode).HasMaxLength(50).IsRequired();


            builder.HasOne(x => x.HealthCondition)
                .WithMany(x => x.DonationRequests)
                .HasForeignKey(x => x.HealthConditionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Donar)
                .WithMany()
                .HasForeignKey(x => x.DonarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
