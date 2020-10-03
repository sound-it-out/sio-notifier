using System;
using System.Threading.Tasks;
using OpenEventSourcing.EntityFrameworkCore.DbContexts;
using OpenEventSourcing.Projections;
using SIO.Domain.Notifications.Events;
using SIO.Domain.Notifications.Projections;

namespace SIO.Domain.Projections.Notifications
{
    public sealed class NotificationQueueProjection : Projection<NotificationQueue>
    {
        private readonly IProjectionDbContextFactory _projectionDbContextFactory;
        public NotificationQueueProjection(IProjectionWriter<NotificationQueue> writer, IProjectionDbContextFactory projectionDbContextFactory) : base(writer)
        {
            if (projectionDbContextFactory == null)
                throw new ArgumentNullException(nameof(projectionDbContextFactory));

            _projectionDbContextFactory = projectionDbContextFactory;

            Handles<AndroidNotificationQueued>(HandleAsync);
            Handles<IosNotificationQueued>(HandleAsync);
            Handles<WindowsNotificationQueued>(HandleAsync);
            Handles<NotificationFailed>(HandleAsync);
            Handles<NotificationSucceded>(HandleAsync);
        }

        public async Task HandleAsync(AndroidNotificationQueued @event)
        {
            await _writer.Add(@event.AggregateId, () =>
            {
                return new NotificationQueue
                {
                    Id = @event.AggregateId,
                    Attempts = 0,
                    Status = NotificationStatus.Pending,
                    Type = NotificationType.Android,
                    Payload = @event.Payload,
                    Tags = @event.Tags,
                    Template = @event.Template,
                    Version = @event.Version,
                };
            });
        }

        public async Task HandleAsync(IosNotificationQueued @event)
        {
            await _writer.Add(@event.AggregateId, () =>
            {
                return new NotificationQueue
                {
                    Id = @event.AggregateId,
                    Attempts = 0,
                    Status = NotificationStatus.Pending,
                    Type = NotificationType.Ios,
                    Payload = @event.Payload,
                    Tags = @event.Tags,
                    Template = @event.Template,
                    Version = @event.Version,
                };
            });
        }

        public async Task HandleAsync(WindowsNotificationQueued @event)
        {
            await _writer.Add(@event.AggregateId, () =>
            {
                return new NotificationQueue
                {
                    Id = @event.AggregateId,
                    Attempts = 0,
                    Status = NotificationStatus.Pending,
                    Type = NotificationType.Windows,
                    Payload = @event.Payload,
                    Tags = @event.Tags,
                    Template = @event.Template,
                    Version = @event.Version,
                };
            });
        }

        public async Task HandleAsync(NotificationFailed @event)
        {
            using(var context = _projectionDbContextFactory.Create())
            {
                var notification = await context.Set<NotificationQueue>().FindAsync(@event.AggregateId);
                if(notification.Attempts == 5)
                {
                    await _writer.Remove(@event.AggregateId);
                }
                else
                {
                    await _writer.Update(@event.AggregateId, n =>
                    {
                        n.Attempts++;
                        n.Status = NotificationStatus.Failed;
                        n.Version = @event.Version;
                    });
                }
            }
        }

        public async Task HandleAsync(NotificationSucceded @event)
        {
            await _writer.Remove(@event.AggregateId);
        }
    }
}
