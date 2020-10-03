using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SIO.Domain.Notifications.Commands;
using SIO.Domain.Notifications.Projections;

namespace SIO.Domain.Notifications.Notifiers
{
    public sealed class AndroidNotifier : BackgroundNotifier
    {
        public AndroidNotifier(ILogger<AndroidNotifier> logger, 
            IServiceScopeFactory serviceScopeFactory) : base(logger, serviceScopeFactory, NotificationType.Android)
        {
        }

        public override Task ProcessAsync(Guid notificationId, int version)
        {
            return _commandDispatcher.DispatchAsync(new ProcessAndroidNotificationCommand(
                aggregateId: notificationId, 
                correlationId: Guid.NewGuid(), 
                version: version, 
                userId: Guid.Empty.ToString()));
        }
    }
}
