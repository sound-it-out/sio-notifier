using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SIO.Infrastructure.Notifications;
using SIO.Migrations.Entities;

namespace SIO.Infrastructure.Azure.Notifications
{
    internal sealed class IosNotifier : BackgroundNotifier<IosNotificationProcessor>
    {
        public IosNotifier(ILogger<BackgroundNotifier<IosNotificationProcessor>> logger, IServiceScopeFactory serviceScopeFactory) : base(logger, serviceScopeFactory)
        {
        }

        protected override Func<Notification, bool> BuildNotificationCheck() => (n) => n.IosAttempts < 5 && !n.IosStatus.HasFlag(NotificationStatus.InProgress) && !n.IosStatus.HasFlag(NotificationStatus.Success);
    }
}
