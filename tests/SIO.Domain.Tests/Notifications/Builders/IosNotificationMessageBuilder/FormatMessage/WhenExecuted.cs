using System;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using OpenEventSourcing.Serialization;
using SIO.Domain.Notifications.Aggregates;
using SIO.Domain.Notifications.Events;
using SIO.Testing.Attributes;

namespace SIO.Domain.Tests.Notifications.Builders.IosNotificationMessageBuilder.FormatMessage
{
    public class WhenExecuted : IosNotificationMessageBuilderSpecification
    {
        private readonly NotificationState _notificationState = new NotificationState
        {
            Template = nameof(NotificationSucceded)
        };
        private string ExpectedMessage => $@"{{ ""aps"" : {{ ""alert"": ""{_notificationState.Template}"" }}}}";
        protected override Task<string> Given()
        {
            return MessageBuilder.BuildAsync(_notificationState);
        }

        protected override Task When()
        {
            var eventSeralizer = _serviceProvider.GetRequiredService<IEventSerializer>();
            _notificationState.Payload = eventSeralizer.Serialize(new NotificationSucceded(Guid.NewGuid(), 0));
            return Task.CompletedTask;
        }

        [Then]
        public void ResultShouldBeExpectedMessage()
        {
            Result.Should().Be(ExpectedMessage);
        }
    }
}
