using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class RescipientConfiguration : IEntityTypeConfiguration<Rescipient>
    {
        public void Configure(EntityTypeBuilder<Rescipient> builder)
        {
            builder.Property(x => x.RescipientCode).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Gender).HasConversion<string>().IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
