using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.DependencyInjection;
using SIO.Infrastructure.Azure.Extensions;
using SIO.Infrastructure.Azure.Notifications;
using SIO.Testing.Abstractions;
using SIO.Testing.Attributes;

namespace SIO.Infrastructure.Azure.Tests.Notifications.NotificationHubClientFactory.Create
{
    public class WhenExectued : SpecificationWithConfiguration<ConfigurationFixture, INotificationHubClient>
    {
        public WhenExectued(ConfigurationFixture configurationFixture) : base(configurationFixture)
        {
        }

        protected override void BuildServices(IServiceCollection services)
        {
            services.AddAzureConfigurations(_configurationFixture.Configuration)
                .AddAzureNotifications();

            base.BuildServices(services);
        }

        protected override Task<INotificationHubClient> Given()
        {
            return Task.FromResult(_serviceProvider.GetRequiredService<INotificationHubClientFactory>().Create());
        }

        protected override Task When()
        {
            return Task.CompletedTask;
        }

        [Integration]
        public void ResultShouldNotBeNull()
        {
            Result.Should().NotBeNull();
        }

        [Integration]
        public async Task ResultShouldBeSuccessfullyConnected()
        {
            var test = await Result.GetAllRegistrationsAsync(1);
        }
    }
}
