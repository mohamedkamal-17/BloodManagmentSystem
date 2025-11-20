using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class ThalassemiaPatientDonorAssignementConfiguration : IEntityTypeConfiguration<ThalassemiaPatientDonorAssignement>
    {
        public void Configure(EntityTypeBuilder<ThalassemiaPatientDonorAssignement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ThalassemiaPatient)
                .WithMany(x => x.thalassemiaPatientDonorAssignements)
                .HasForeignKey(x => x.ThalassemiaPatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Donar)
                .WithMany(x => x.thalassemiaPatientDonorAssignements)
                .HasForeignKey(x => x.DonarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
