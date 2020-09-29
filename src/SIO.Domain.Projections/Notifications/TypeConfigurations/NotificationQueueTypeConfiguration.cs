using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenEventSourcing.EntityFrameworkCore.EntityConfiguration;
using OpenEventSourcing.EntityFrameworkCore.Extensions;
using SIO.Domain.Notifications.Projections;

namespace SIO.Domain.Projections.Notifications.TypeConfigurations
{
    internal class NotificationQueueTypeConfiguration : IProjectionTypeConfiguration<NotificationQueue>
    {
        public void Configure(EntityTypeBuilder<NotificationQueue> builder)
        {
            builder.ToTable(nameof(NotificationQueue));
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                   .ValueGeneratedNever();
            builder.Property(i => i.Tags)
                .HasJsonValueConversion();
        }
    }
}
