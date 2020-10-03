using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SIO.Domain.Tests.Notifications.Notifiers.AndroidNotifier
{
    public abstract class AndroidNotifierSpecification : NotifierSpecification
    {
        private readonly Lazy<Domain.Notifications.Notifiers.AndroidNotifier> _lazyAndroidNotifier;
        protected Domain.Notifications.Notifiers.AndroidNotifier AndroidNotifier => _lazyAndroidNotifier.Value;

        public AndroidNotifierSpecification()
        {
            _lazyAndroidNotifier = new Lazy<Domain.Notifications.Notifiers.AndroidNotifier>(() =>
            {
                foreach (var service in _serviceProvider.GetServices<IHostedService>())
                {
                    if (service is Domain.Notifications.Notifiers.AndroidNotifier)
                        return (Domain.Notifications.Notifiers.AndroidNotifier)service;
                }

                return null;
            });
        }
    }
}
