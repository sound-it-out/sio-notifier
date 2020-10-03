using System;
using System.Collections.Generic;
using FluentAssertions;
using OpenEventSourcing.Events;
using OpenEventSourcing.Extensions;
using SIO.Domain.Notifications.Events;
using SIO.Domain.Notifications.Projections;
using SIO.Testing.Abstractions;
using SIO.Testing.Attributes;

namespace SIO.Domain.Projections.Tests.Notifications.NotificationQueueProjection
{
    public class WhenIosNotificationQueued : ProjectionSpecification<Projections.Notifications.NotificationQueueProjection>
    {
        private readonly Guid _aggregateId = Guid.NewGuid().ToSequentialGuid();
        private readonly string _template = "Test template";
        private readonly string _payload = "Test payload";
        private readonly IEnumerable<string> _tags = new string[] { Guid.NewGuid().ToSequentialGuid().ToString() };

        protected override IEnumerable<IEvent> Given()
        {
            yield return new IosNotificationQueued(_aggregateId, 1, _template, _payload, _tags);
        }

        [Then]
        public void NotificaionShouldNotBeNull()
        {
            var notification = Context.Find<NotificationQueue>(_aggregateId);
            notification.Should().NotBeNull();
        }

        [Then]
        public void NotificaionShouldHaveCorrectId()
        {
            var notification = Context.Find<NotificationQueue>(_aggregateId);
            notification.Id.Should().Be(_aggregateId);
        }

        [Then]
        public void NotificaionShouldHaveCorrectTemplate()
        {
            var notification = Context.Find<NotificationQueue>(_aggregateId);
            notification.Template.Should().Be(_template);
        }

        [Then]
        public void NotificaionShouldHaveCorrectPayload()
        {
            var notification = Context.Find<NotificationQueue>(_aggregateId);
            notification.Payload.Should().Be(_payload);
        }

        [Then]
        public void NotificaionShouldHaveCorrectTags()
        {
            var notification = Context.Find<NotificationQueue>(_aggregateId);
            notification.Tags.Should().BeEquivalentTo(_tags);
        }

        [Then]
        public void NotificaionShouldHaveCorrectType()
        {
            var notification = Context.Find<NotificationQueue>(_aggregateId);
            notification.Type.Should().Be(NotificationType.Ios);
        }

        [Then]
        public void NotificaionShouldHaveCorrectStatus()
        {
            var notification = Context.Find<NotificationQueue>(_aggregateId);
            notification.Status.Should().Be(NotificationStatus.Pending);
        }

        [Then]
        public void NotificaionShouldHaveCorrectAttempts()
        {
            var notification = Context.Find<NotificationQueue>(_aggregateId);
            notification.Attempts.Should().Be(0);
        }

        [Then]
        public void NotificaionShouldHaveCorrectVersion()
        {
            var notification = Context.Find<NotificationQueue>(_aggregateId);
            notification.Version.Should().Be(1);
        }
    }
}
