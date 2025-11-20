using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class HealthConditionConfiguration : IEntityTypeConfiguration<HealthCondition>
    {
        public void Configure(EntityTypeBuilder<HealthCondition> builder)
        {
            builder.HasMany(x => x.DonationRequests)
                .WithOne(x => x.HealthCondition)
                .HasForeignKey(x => x.HealthConditionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
