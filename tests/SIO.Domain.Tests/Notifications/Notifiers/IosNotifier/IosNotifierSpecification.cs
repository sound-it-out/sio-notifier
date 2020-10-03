using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SIO.Domain.Tests.Notifications.Notifiers.IosNotifier
{
    public abstract class IosNotifierSpecification : NotifierSpecification
    {
        private readonly Lazy<Domain.Notifications.Notifiers.IosNotifier> _lazyIosNotifier;
        protected Domain.Notifications.Notifiers.IosNotifier IosNotifier => _lazyIosNotifier.Value;

        public IosNotifierSpecification()
        {
            _lazyIosNotifier = new Lazy<Domain.Notifications.Notifiers.IosNotifier>(() =>
            {
                foreach (var service in _serviceProvider.GetServices<IHostedService>())
                {
                    if (service is Domain.Notifications.Notifiers.IosNotifier)
                        return (Domain.Notifications.Notifiers.IosNotifier)service;
                }

                return null;
            });
        }
    }
}
