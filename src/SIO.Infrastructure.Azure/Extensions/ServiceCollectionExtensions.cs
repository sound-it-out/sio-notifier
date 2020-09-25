using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIO.Infrastructure.Azure.Notifications;

namespace SIO.Infrastructure.Azure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAzureInfrastructure(this IServiceCollection source)
        {
            return source.AddAzureNotifications();            
        }

        public static IServiceCollection AddAzureConfigurations(this IServiceCollection source, IConfiguration configuration)
        {
            return source.AddAzureNotificationConfiguration(configuration);
        }

        public static IServiceCollection AddAzureNotificationConfiguration(this IServiceCollection source, IConfiguration configuration)
        {
            source.Configure<AzureNotificationOptions>(configuration.GetSection("Azure:Notifications"));

            return source;
        }

        public static IServiceCollection AddAzureNotifications(this IServiceCollection source)
        {
            source.AddScoped<AndroidNotificationProcessor>();
            source.AddScoped<IosNotificationProcessor>();
            source.AddScoped<WindowsNotificationProcessor>();

            source.AddHostedService<AndroidNotifier>();
            source.AddHostedService<IosNotifier>();
            source.AddHostedService<WindowsNotifier>();
            source.AddSingleton<INotificationHubClientFactory, NotificationHubClientFactory>();

            return source;
        }
    }
}
