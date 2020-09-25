using System;
using System.Threading.Tasks;
using SIO.Testing.Attributes;

namespace SIO.Infrastructure.Azure.Tests.Notifications.AndroidNotificationProcessor
{
    public class WhenNotificationIsSentToHub : AndroidNotificationProcessorSpecificationWithConfiguration
    {
        public WhenNotificationIsSentToHub(ConfigurationFixture configurationFixture, AzureNotificationProcessorFixture azureNotificationProcessorFixture) : base(configurationFixture, azureNotificationProcessorFixture)
        {
        }

        protected override Task Given()
        {
            throw new NotImplementedException();
        }

        protected override Task When()
        {
            throw new NotImplementedException();
        }

        [Integration]
        public Task NotificationShouldHaveSingleAttempt()
        {
            return Task.CompletedTask;
        }

        [Integration]
        public Task NotificationShouldHaveSuccessStatus()
        {
            return Task.CompletedTask;
        }

        [Integration]
        public Task AndroidNotificationSuccessEventShouldBePublished()
        {
            return Task.CompletedTask;
        }
    }
}
