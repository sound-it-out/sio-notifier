using Microsoft.Extensions.DependencyInjection;
using SIO.Infrastructure.Azure.Extensions;
using SIO.Testing.Abstractions;

namespace SIO.Infrastructure.Azure.Tests.Notifications
{
    public abstract class AzureNotificationProcessorSpecificationWithConfiguration : SpecificationWithConfiguration<ConfigurationFixture>
    {
        protected AzureNotificationProcessorSpecificationWithConfiguration(ConfigurationFixture configurationFixture) : base(configurationFixture)
        {
        }

        protected override void BuildServices(IServiceCollection services)
        {
            base.BuildServices(services);
            services.AddAzureNotifications();
        }
    }
}
