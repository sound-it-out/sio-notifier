using System;
using System.Threading;
using System.Threading.Tasks;
using SIO.Infrastructure.Notifications;
using SIO.Migrations.Entities;

namespace SIO.Infrastructure.Azure.Tests.Notifications
{
    public class AzureNotificationProcessorFixture : INotificationProcessor, IDisposable
    {
        private INotificationProcessor _notificationProcessor;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private Task _processAsync;
        private readonly object _processAsyncLock = new object();

        public void Init(INotificationProcessor notificationProcessor) => _notificationProcessor = notificationProcessor;

        public void Dispose()
        {
            _cts.Cancel();
        }

        public Task ProcessAsync(Notification notification)
        {
            lock (_processAsyncLock)
            {
                if (_processAsync == null)
                {
                    _processAsync = Task.Run(async () => await _notificationProcessor.ProcessAsync(notification), _cts.Token);
                }
            }

            return _processAsync;
        }
    }
}
