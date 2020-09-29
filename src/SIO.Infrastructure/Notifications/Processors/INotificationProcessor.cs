using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIO.Infrastructure.Notifications.Processors
{
    public interface INotificationProcessor
    {
        Task ProcessAsync(string message, IEnumerable<string> tags);
    }
}
