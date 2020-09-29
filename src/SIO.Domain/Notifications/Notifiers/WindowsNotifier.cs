using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenEventSourcing.Commands;
using SIO.Domain.Notifications.Commands;
using SIO.Domain.Notifications.Projections;

namespace SIO.Domain.Notifications.Notifiers
{
    internal sealed class WindowsNotifier : BackgroundNotifier
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public WindowsNotifier(ILogger<IosNotifier> logger, 
            IServiceScopeFactory serviceScopeFactory,
            ICommandDispatcher commandDispatcher) : base(logger, serviceScopeFactory, NotificationType.Windows)
        {
            if (commandDispatcher == null)
                throw new ArgumentNullException(nameof(commandDispatcher));

            _commandDispatcher = commandDispatcher;
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
