using Microsoft.Azure.NotificationHubs;

namespace SIO.Infrastructure.Azure.Notifications
{
    internal interface INotificationHubClientFactory
    {
        INotificationHubClient Create();
    }
}
