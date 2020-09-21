using System;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;
using SIO.Infrastructure.Events;
using SIO.Infrastructure.Notifications;

namespace SIO.Infrastructure.Azure.Notifications
{
    internal abstract class AzureNotificationProcessor : INotificationProcessor
    {
        protected readonly INotificationHubClient _notificationHubClient;
        protected readonly INotificationMessageBuilder _notificationMessageBuilder;
        protected readonly IEventPublisher _eventPublisher;

        public AzureNotificationProcessor(INotificationHubClientFactory notificationHubClientFactory,
            INotificationMessageBuilder notificationMessageBuilder,
            IEventPublisher eventPublisher)
        {
            if (notificationHubClientFactory == null)
                throw new ArgumentNullException(nameof(notificationHubClientFactory));
            if (notificationMessageBuilder == null)
                throw new ArgumentNullException(nameof(notificationMessageBuilder));
            if (eventPublisher == null)
                throw new ArgumentNullException(nameof(eventPublisher));

            _notificationHubClient = notificationHubClientFactory.Create();
            _notificationMessageBuilder = notificationMessageBuilder;
            _eventPublisher = eventPublisher;
        }

        public abstract Task ProcessAsync(Migrations.Entities.Notification notification);
    }
}
