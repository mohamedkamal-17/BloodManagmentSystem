using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class BloodUnitConfiguration : IEntityTypeConfiguration<BloodUnit>
    {
        public void Configure(EntityTypeBuilder<BloodUnit> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.StorageLocation)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.BloodGroup)
                   .HasConversion<string>() // Store enum as string
                   .IsRequired();

            builder.Property(x => x.Status)
                   .HasConversion<string>() // Store enum as string
                   .IsRequired();

            builder.Property(x => x.DonationDate)
                   .IsRequired();

            builder.Property(x => x.ExpiryDate)
                   .IsRequired();

            builder.HasOne(x => x.BloodInventory)
           .WithMany(x => x.BloodUnits)
           .HasForeignKey(x => x.BloodInventoryId)
           .OnDelete(DeleteBehavior.Restrict);


            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");


        }
    }
}
