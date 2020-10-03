using System.Threading.Tasks;
using SIO.Domain.Notifications.Aggregates;
using SIO.Domain.Notifications.Builders;

namespace SIO.Testing.Fakes.Notifications.Builders
{
    public sealed class FakeWindowsNotificationMessageBuilder : IWindowsNotificationMessageBuilder
    {
        public Task<string> BuildAsync(NotificationState notification)
        {
            return Task.FromResult(notification.Template);
        }
    }
}
