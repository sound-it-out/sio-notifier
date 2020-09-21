using System;
using System.Threading.Tasks;
using OpenEventSourcing.Commands;
using SIO.Domain.Notifications.Commands;
using SIO.Domain.Notifications.Events;
using SIO.Infrastructure.Events;
using SIO.Migrations.DbContexts;
using SIO.Migrations.Entities;

namespace SIO.Domain.Notifications.CommandHandlers
{
    internal class QueueNotificationCommandHandler : ICommandHandler<QueueNotificationCommand>
    {
        private readonly ISIONotifierDbContextFactory _contextFactory;
        private readonly IEventPublisher _eventPublisher;

        public QueueNotificationCommandHandler(ISIONotifierDbContextFactory contextFactory, IEventPublisher eventPublisher)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));
            if (eventPublisher == null)
                throw new ArgumentNullException(nameof(eventPublisher));

            _contextFactory = contextFactory;
            _eventPublisher = eventPublisher;
        }

        public async Task ExecuteAsync(QueueNotificationCommand command)
        {
            using (var context = _contextFactory.Create())
            {
                var notification = new Notification
                {
                    CausationId = command.Id,
                    Id = command.AggregateId,
                    Tags = new string[1] { command.UserId },
                    Payload = command.Payload,
                    Template = command.Template
                };

                await context.AddAsync(notification);
                await context.SaveChangesAsync();

                var notificationQueueEvent = new NotificationQueued(command.AggregateId, 0);
                notificationQueueEvent.UpdateFrom(command);
                await _eventPublisher.PublishAsync(notificationQueueEvent);
            }
        }
    }
}
