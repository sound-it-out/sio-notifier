using Microsoft.Extensions.DependencyInjection;
using SIO.Infrastructure.Events;
using SIO.Infrastructure.Notifications;

namespace SIO.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection source)
        {
            source.AddHostedService<EventConsumer>();
            return source;
        }
    }
}
