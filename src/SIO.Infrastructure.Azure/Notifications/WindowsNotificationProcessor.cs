using System;
using System.Threading.Tasks;
using SIO.Domain.Notifications.Events;
using SIO.Infrastructure.Events;
using SIO.Infrastructure.Notifications;
using SIO.Migrations.DbContexts;
using SIO.Migrations.Entities;

namespace SIO.Infrastructure.Azure.Notifications
{
    internal sealed class WindowsNotificationProcessor : AzureNotificationProcessor
    {
        private readonly ISIONotifierDbContextFactory _contextFactory;
        public WindowsNotificationProcessor(INotificationHubClientFactory notificationHubClientFactory, INotificationMessageBuilder notificationMessageBuilder, IEventPublisher eventPublisher, ISIONotifierDbContextFactory contextFactory) : base(notificationHubClientFactory, notificationMessageBuilder, eventPublisher)
        {
            if (contextFactory == null)
                throw new ArgumentNullException(nameof(contextFactory));

            _contextFactory = contextFactory;
        }

        public override async Task ProcessAsync(Notification notification)
        {
            using (var context = _contextFactory.Create())
            {
                await context.Entry(notification).ReloadAsync();
                notification.WindowsStatus = NotificationStatus.InProgress;
                await context.SaveChangesAsync();


                notification.WindowsAttempts++;

                try
                {
                    NotificationMessage message = await _notificationMessageBuilder.BuildAsync(notification);
                    await _notificationHubClient.SendAdmNativeNotificationAsync(message.ToAndroid(), tags: notification.Tags);
                    notification.WindowsStatus = NotificationStatus.Success;
                    await _eventPublisher.PublishAsync(new WindowsNotificationSuccess(notification.Id, 0, Guid.NewGuid(), notification.CausationId, Guid.Empty.ToString()));
                }
                catch (Exception e)
                {
                    notification.WindowsStatus = NotificationStatus.Failed;
                    await _eventPublisher.PublishAsync(new WindowsNotificationFailed(notification.Id, 0, Guid.NewGuid(), notification.CausationId, e.Message, Guid.Empty.ToString()));
                }
                finally
                {
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
