using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenEventSourcing.Extensions;
using OpenEventSourcing.Serialization.Json.Extensions;
using SIO.Infrastructure.Azure.Extensions;
using SIO.Infrastructure.Azure.Notifications;
using SIO.Infrastructure.Azure.Tests.Stubs;
using SIO.Infrastructure.Extensions;
using SIO.Infrastructure.Notifications;
using SIO.Migrations.Extensions;
using SIO.Testing.Abstractions;
using SIO.Testing.Extensions;
using Xunit;

namespace SIO.Infrastructure.Azure.Tests.Notifications
{
    public abstract class AzureNotificationProcessorSpecification : SpecificationWithConfiguration<ConfigurationFixture>, IClassFixture<ConfigurationFixture>
    {
        public AzureNotificationProcessorSpecification(ConfigurationFixture configurationFixture) : base(configurationFixture)
        {
        }

        protected override void BuildServices(IServiceCollection services)
        {
            base.BuildServices(services);
            services
                .AddInfrastructure()
                .AddAzureNotifications()
                .AddMigrations()
                .AddInMemoryDatabase()
                .AddInMemoryEventBus();

            services.AddOpenEventSourcing()
                .AddEvents()
                .AddJsonSerializers();

            services.AddLogging();

            services.RemoveAll<INotificationHubClientFactory>();
            services.RemoveAll<INotificationMessageBuilder>();

            services.AddSingleton<INotificationHubClientFactory>(new FakeNotificationHubClientFactory(ThrowException()));
            services.AddSingleton<INotificationMessageBuilder, FakeNotificationMessageBuilder>();
        }

        protected abstract bool ThrowException();
    }
}
