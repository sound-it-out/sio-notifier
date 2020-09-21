using System;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Options;

namespace SIO.Infrastructure.Azure.Notifications
{
    internal sealed class NotificationHubClientFactory : INotificationHubClientFactory
    {
        private readonly AzureNotificationOptions _notificationOptions;
        public NotificationHubClientFactory(IOptions<AzureNotificationOptions> notificationOptions)
        {
            if (notificationOptions == null)
                throw new ArgumentNullException(nameof(notificationOptions));

            _notificationOptions = notificationOptions.Value;
        }

        public INotificationHubClient Create()
        {
            return NotificationHubClient.CreateClientFromConnectionString(_notificationOptions.ConnectionString, _notificationOptions.HubPath);
        }
    }
}
