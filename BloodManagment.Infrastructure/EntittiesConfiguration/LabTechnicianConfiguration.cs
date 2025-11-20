using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class LabTechnicianConfiguration : IEntityTypeConfiguration<LabTechnician>
    {
        public void Configure(EntityTypeBuilder<LabTechnician> builder)
        {
            builder.Property(x => x.HireDate).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Hospital)
                .WithMany(x => x.LabTechnicians)
                .HasForeignKey(x => x.HospitalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
