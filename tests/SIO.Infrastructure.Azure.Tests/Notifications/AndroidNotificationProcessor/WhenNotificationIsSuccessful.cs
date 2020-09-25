using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OpenEventSourcing.Serialization;
using SIO.Migrations.DbContexts;
using SIO.Migrations.Entities;
using SIO.Testing.Attributes;
using SIO.Testing.Stubs;

namespace SIO.Infrastructure.Azure.Tests.Notifications.AndroidNotificationProcessor
{
    public class WhenNotificationIsSuccessful : AndroidNotificationProcessorSpecification
    {
        private Notification _notification;

        public WhenNotificationIsSuccessful(ConfigurationFixture configurationFixture, AzureNotificationProcessorFixture azureNotificationProcessorFixture) : base(configurationFixture, azureNotificationProcessorFixture)
        {
        }

        protected override Task Given()
        {
            return NotificationProcessor.ProcessAsync(_notification);
        }

        protected override async Task When()
        {
            var eventSerializer = _serviceProvider.GetRequiredService<IEventSerializer>();
            var contextFactory = _serviceProvider.GetRequiredService<ISIONotifierDbContextFactory>();

            var context = contextFactory.Create();
            _notification = new Notification
            {
                CausationId = Guid.NewGuid(),
                Id = Guid.NewGuid(),
                Tags = new string[1] { Guid.NewGuid().ToString() },
                Payload = eventSerializer.Serialize(new TestEvent(Guid.NewGuid(), 0)),
                Template = nameof(TestEvent)
            };

            await context.AddAsync(_notification);
            await context.SaveChangesAsync();
        }

        protected override bool ThrowException() => false;

        [Then]
        public async Task NotificationShouldHaveSingleAttempt()
        {
            var contextFactory = _serviceProvider.GetRequiredService<ISIONotifierDbContextFactory>();
            using (var context = contextFactory.Create())
            {
                var notification = await context.Notifications.FindAsync(_notification.Id);
                notification.AndroidAttempts.Should().Be(1);
            }
        }

        [Then]
        public async Task NotificationShouldHaveSuccessStatus()
        {
            var contextFactory = _serviceProvider.GetRequiredService<ISIONotifierDbContextFactory>();
            using (var context = contextFactory.Create())
            {
                var notification = await context.Notifications.FindAsync(_notification.Id);
                notification.AndroidStatus.Should().Be(NotificationStatus.Success);
            }
        }

        [Then]
        public async Task AndroidNotificationSuccessEventShouldBePublished()
        {
            //var contextFactory = _serviceProvider.GetRequiredService<ISIONotifierDbContextFactory>();
            //using (var context = contextFactory.Create())
            //{
            //    var notification = await context.Notifications.FindAsync(_notification.Id);
            //    notification.AndroidAttempts.Should().Be(1);
            //}
        }        
    }
}
