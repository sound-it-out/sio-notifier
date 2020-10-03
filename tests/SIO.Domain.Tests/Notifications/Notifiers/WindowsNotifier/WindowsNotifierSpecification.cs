using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SIO.Domain.Tests.Notifications.Notifiers.WindowsNotifier
{
    public abstract class WindowsNotifierSpecification : NotifierSpecification
    {
        private readonly Lazy<Domain.Notifications.Notifiers.WindowsNotifier> _lazyWindowsNotifier;
        protected Domain.Notifications.Notifiers.WindowsNotifier WindowsNotifier => _lazyWindowsNotifier.Value;

        public WindowsNotifierSpecification()
        {
            _lazyWindowsNotifier = new Lazy<Domain.Notifications.Notifiers.WindowsNotifier>(() =>
            {
                foreach (var service in _serviceProvider.GetServices<IHostedService>())
                {
                    if (service is Domain.Notifications.Notifiers.WindowsNotifier)
                        return (Domain.Notifications.Notifiers.WindowsNotifier)service;
                }

                return null;
            });
        }
    }
}
