using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using SIO.Domain.Notifications.Builders;
using SIO.Domain.Notifications.Notifiers;

namespace SIO.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection source)
        {
            source.AddHostedService<AndroidNotifier>();
            source.AddHostedService<IosNotifier>();
            source.AddHostedService<WindowsNotifier>();

            source.AddTransient<IAndroidNotificationMessageBuilder, AndroidNotificationMessageBuilder>();
            source.AddTransient<IIosNotificationMessageBuilder, IosNotificationMessageBuilder>();
            source.AddTransient<IWindowsNotificationMessageBuilder, WindowsNotificationMessageBuilder>();

            return source;
        }
    }
}
