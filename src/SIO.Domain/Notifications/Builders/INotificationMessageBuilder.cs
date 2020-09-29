using System.Threading.Tasks;
using SIO.Domain.Notifications.Aggregates;

namespace SIO.Domain.Notifications.Builders
{
    public interface INotificationMessageBuilder
    {
        Task<string> BuildAsync(NotificationState notification);
    }
}
