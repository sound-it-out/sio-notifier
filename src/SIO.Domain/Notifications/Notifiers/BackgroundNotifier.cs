using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenEventSourcing.EntityFrameworkCore.DbContexts;
using SIO.Domain.Notifications.Projections;

namespace SIO.Domain.Notifications.Notifiers
{
    public abstract class BackgroundNotifier : IHostedService
    {
        private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();
        private readonly ILogger<BackgroundNotifier> _logger;
        private readonly IServiceScope _scope;
        private readonly NotificationType _notificationType;

        private Task _executingTask;

        public BackgroundNotifier(ILogger<BackgroundNotifier> logger,
            IServiceScopeFactory serviceScopeFactory,
            NotificationType notificationType)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (serviceScopeFactory == null)
                throw new ArgumentNullException(nameof(serviceScopeFactory));

            _logger = logger;
            _notificationType = notificationType;
            _scope = serviceScopeFactory.CreateScope();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _executingTask = ExecuteAsync(_stoppingCts.Token);

            if (_executingTask.IsCompleted)
                return _executingTask;

            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _scope.Dispose();
            if (_executingTask == null)
                return;

            try
            {
                _stoppingCts.Cancel();
            }
            finally
            {
                await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }

        public void Dispose()
        {
            _stoppingCts.Cancel();
        }

        public abstract Task ProcessAsync(Guid notificationId, int version);

        private async Task PollAsync(CancellationToken cancellationToken)
        {
            using (var context = _scope.ServiceProvider.GetRequiredService<IProjectionDbContextFactory>().Create())
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var notificationIds = await context.Set<NotificationQueue>().Where(n => n.Type == _notificationType).ToArrayAsync();

                        foreach (var notification in notificationIds)
                            await ProcessAsync(notification.Id, notification.Version);

                        await Task.Delay(500);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogCritical(ex, $"Projection '{GetType().Name}' failed due to an unexpected error. See exception details for more information.");
                        break;
                    }
                }
            }
        }

        protected Task ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => PollAsync(cancellationToken));
        }
    }
}
