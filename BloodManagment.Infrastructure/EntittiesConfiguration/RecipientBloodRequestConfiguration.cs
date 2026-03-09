using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class RecipientBloodRequestConfiguration : IEntityTypeConfiguration<RecipientBloodRequestHistory>
    {
        public void Configure(EntityTypeBuilder<RecipientBloodRequestHistory> builder)
        {
            builder.Property(x => x.HospitalName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Diagnosis).HasMaxLength(200);

            builder.Property(x => x.Notes).HasMaxLength(500);

            builder.HasOne(x => x.Recipient)
                .WithMany()
                .HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
