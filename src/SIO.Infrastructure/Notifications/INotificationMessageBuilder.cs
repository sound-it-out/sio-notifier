using System.Threading.Tasks;
using SIO.Migrations.Entities;

namespace SIO.Infrastructure.Notifications
{
    public interface INotificationMessageBuilder
    {
        Task<string> BuildAsync(Notification notification);
    }
}
