using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SIO.Migrations.DbContexts;
using SIO.Migrations.Entities;

namespace SIO.Infrastructure.Notifications
{
    public abstract class BackgroundNotifier<TNotificationProcessor> : IHostedService
        where TNotificationProcessor : INotificationProcessor
    {
        private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();
        private readonly ILogger<BackgroundNotifier<TNotificationProcessor>> _logger;
        private readonly IServiceScope _scope;
        private readonly TNotificationProcessor _notificationProcessor;
        private readonly Func<Notification, bool> _notificationCheck;

        private Task _executingTask;

        public BackgroundNotifier(ILogger<BackgroundNotifier<TNotificationProcessor>> logger,
            IServiceScopeFactory serviceScopeFactory)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
            if (serviceScopeFactory == null)
                throw new ArgumentNullException(nameof(serviceScopeFactory));

            _logger = logger;
            _scope = serviceScopeFactory.CreateScope();
            _notificationProcessor = _scope.ServiceProvider.GetRequiredService<TNotificationProcessor>();
            _notificationCheck = BuildNotificationCheck();
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

        protected abstract Func<Notification, bool> BuildNotificationCheck();

        private async Task PollAsync(CancellationToken cancellationToken)
        {
            using (var context = _scope.ServiceProvider.GetRequiredService<SIONotifierDbContext>())
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var notifications = await context.Notifications.Where(n => _notificationCheck(n)).ToArrayAsync();

                        foreach (var notification in notifications)
                            await _notificationProcessor.ProcessAsync(notification);

                        await Task.Delay(500);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogCritical(ex, $"Projection '{typeof(BackgroundNotifier<TNotificationProcessor>).Name}' failed due to an unexpected error. See exception details for more information.");
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
