using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SIO.Infrastructure.Notifications;
using SIO.Migrations.Entities;

namespace SIO.Infrastructure.Azure.Notifications
{
    internal sealed class AndroidNotifier : BackgroundNotifier<AndroidNotificationProcessor>
    {
        public AndroidNotifier(ILogger<BackgroundNotifier<AndroidNotificationProcessor>> logger, IServiceScopeFactory serviceScopeFactory) : base(logger, serviceScopeFactory)
        {
        }

        protected override Func<Notification, bool> BuildNotificationCheck() => (n) => n.AndroidAttempts < 5 && !n.AndroidStatus.HasFlag(NotificationStatus.InProgress) && !n.AndroidStatus.HasFlag(NotificationStatus.Success);
    }
}
