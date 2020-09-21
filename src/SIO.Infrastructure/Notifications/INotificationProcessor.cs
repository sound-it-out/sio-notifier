using System.Threading.Tasks;
using SIO.Migrations.Entities;

namespace SIO.Infrastructure.Notifications
{
    public interface INotificationProcessor
    {
        Task ProcessAsync(Notification notification);
    }
}
