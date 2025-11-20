using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class DonarConfiguration : IEntityTypeConfiguration<Donar>
    {
        public void Configure(EntityTypeBuilder<Donar> builder)
        {
            builder.Property(x => x.DonarCode).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.thalassemiaPatientDonorAssignements)
                .WithOne(x => x.Donar)
                .HasForeignKey(x => x.DonarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
