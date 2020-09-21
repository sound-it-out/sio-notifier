using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SIO.Infrastructure.Notifications;
using SIO.Migrations.Entities;

namespace SIO.Infrastructure.Azure.Notifications
{
    internal sealed class WindowsNotifier : BackgroundNotifier<WindowsNotificationProcessor>
    {
        public WindowsNotifier(ILogger<BackgroundNotifier<WindowsNotificationProcessor>> logger, IServiceScopeFactory serviceScopeFactory) : base(logger, serviceScopeFactory)
        {
        }

        protected override Func<Notification, bool> BuildNotificationCheck() => (n) => n.WindowsAttempts < 5 && !n.WindowsStatus.HasFlag(NotificationStatus.InProgress) && !n.WindowsStatus.HasFlag(NotificationStatus.Success);
    }
}
