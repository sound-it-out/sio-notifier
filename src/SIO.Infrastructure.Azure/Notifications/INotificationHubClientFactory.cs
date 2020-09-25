using Microsoft.Azure.NotificationHubs;

namespace SIO.Infrastructure.Azure.Notifications
{
    public interface INotificationHubClientFactory
    {
        INotificationHubClient Create();
    }
}
