using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenEventSourcing.EntityFrameworkCore.EntityConfiguration;
using SIO.Domain.Notifications.Projections;

namespace SIO.Domain.Projections.Notifications.TypeConfigurations
{
    internal class NotificationFailureTypeConfiguration : IProjectionTypeConfiguration<NotificationFailure>
    {
        public void Configure(EntityTypeBuilder<NotificationFailure> builder)
        {
            builder.ToTable(nameof(NotificationFailure));
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                   .ValueGeneratedNever();
            builder.HasIndex(i => i.NotificationId);
        }
    }
}
