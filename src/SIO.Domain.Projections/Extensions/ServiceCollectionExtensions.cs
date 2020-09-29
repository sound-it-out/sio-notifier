using System;
using Microsoft.Extensions.DependencyInjection;
using SIO.Domain.Projections.Notifications;

namespace SIO.Domain.Projections.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjections(this IServiceCollection source)
        {
            source.AddScoped<NotificationQueueProjection>();
            source.AddScoped<NotificationFailureProjection>();

            source.AddHostedService<PollingProjector<NotificationQueueProjection>>();
            source.AddHostedService<PollingProjector<NotificationFailureProjection>>();

            return source;
        }
    }
}
