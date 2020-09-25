using System;
using System.Threading.Tasks;
using SIO.Testing.Attributes;

namespace SIO.Infrastructure.Azure.Tests.Notifications.AndroidNotificationProcessor
{
    public class WhenNotificationIsNotSuccessful : AndroidNotificationProcessorSpecification
    {
        public WhenNotificationIsNotSuccessful(ConfigurationFixture configurationFixture, AzureNotificationProcessorFixture azureNotificationProcessorFixture) : base(configurationFixture, azureNotificationProcessorFixture)
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

        protected override bool ThrowException() => true;

        [Then]
        public Task NotificationShouldHaveSingleAttempt()
        {
            return Task.CompletedTask;
        }

        [Then]
        public Task NotificationShouldHaveFailedStatus()
        {
            return Task.CompletedTask;
        }

        [Then]
        public Task AndroidNotificationFailedEventShouldBePublished()
        {
            return Task.CompletedTask;
        }        
    }
}
