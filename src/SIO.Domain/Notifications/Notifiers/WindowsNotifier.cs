using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SIO.Domain.Notifications.Commands;
using SIO.Domain.Notifications.Projections;

namespace SIO.Domain.Notifications.Notifiers
{
    public sealed class WindowsNotifier : BackgroundNotifier
    {
        public WindowsNotifier(ILogger<IosNotifier> logger, 
            IServiceScopeFactory serviceScopeFactory) : base(logger, serviceScopeFactory, NotificationType.Windows)
        {
        }

        public override Task ProcessAsync(Guid notificationId, int version)
        {
            return _commandDispatcher.DispatchAsync(new ProcessWindowsNotificationCommand(
                aggregateId: notificationId, 
                correlationId: Guid.NewGuid(), 
                version: version, 
                userId: Guid.Empty.ToString()));
        }
    }
}
