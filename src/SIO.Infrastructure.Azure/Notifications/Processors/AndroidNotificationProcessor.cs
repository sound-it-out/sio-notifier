using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;
using SIO.Infrastructure.Notifications.Processors;

namespace SIO.Infrastructure.Azure.Notifications.Processors
{
    internal sealed class AndroidNotificationProcessor : IAndroidNotificationProcessor
    {
        private readonly INotificationHubClient _notificationHubClient;

        public AndroidNotificationProcessor(INotificationHubClientFactory notificationHubClientFactory)
        {
            if (notificationHubClientFactory == null)
                throw new ArgumentNullException(nameof(notificationHubClientFactory));

            _notificationHubClient = notificationHubClientFactory.Create();
        }

        public Task ProcessAsync(string message, IEnumerable<string> tags)
        {
            return _notificationHubClient.SendFcmNativeNotificationAsync(jsonPayload: message, tags: tags);
        }
    }
}
