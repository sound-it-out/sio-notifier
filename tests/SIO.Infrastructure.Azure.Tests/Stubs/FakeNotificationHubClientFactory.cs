using Microsoft.Azure.NotificationHubs;
using SIO.Infrastructure.Azure.Notifications;

namespace SIO.Infrastructure.Azure.Tests.Stubs
{
    internal sealed class FakeNotificationHubClientFactory : INotificationHubClientFactory
    {
        private readonly bool _throwException;

        public FakeNotificationHubClientFactory(bool throwException)
        {
            _throwException = throwException;
        }

        public INotificationHubClient Create()
        {
            return new FakeNotificationHubClient(_throwException);
        }
    }
}
