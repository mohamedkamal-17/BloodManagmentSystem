using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{


    public class BloodInventoryConfiguration : IEntityTypeConfiguration<BloodInventory>
    {
        public void Configure(EntityTypeBuilder<BloodInventory> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Quantity)
                   .IsRequired();

            builder.Property(x => x.BloodGroup)

                   .IsRequired();

            builder.Property(x => x.Status)

                   .IsRequired();

            // Relationships
            builder.HasOne(x => x.Hospital)
                   .WithMany(x => x.BloodInventories)
                   .HasForeignKey(x => x.HospitalId)
                   .OnDelete(DeleteBehavior.Restrict);



            // Audit & Soft Delete
            builder.Property(x => x.IsDeleted)
                   .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Optional: Index
            builder.HasIndex(x => x.BloodGroup);
        }
    }
}


