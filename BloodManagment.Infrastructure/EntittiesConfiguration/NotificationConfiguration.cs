using BloodManagment.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodManagment.Infrastructure.EntittiesConfiguration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Message).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Type).HasConversion<string>().IsRequired();

            builder.HasOne(x => x.Rescipient)
                .WithMany(x => x.Notification)
                .HasForeignKey(x => x.RescipientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Donar)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.DonarId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ThalassemiaPatient)
                .WithMany()
                .HasForeignKey(x => x.ThalassemiaPatientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BloodRequest)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.BloodRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DonationRequest)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.DonationRequestId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }


}
