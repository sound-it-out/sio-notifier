using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using OpenEventSourcing.Events;
using OpenEventSourcing.Extensions;
using SIO.Domain.Notifications.Aggregates;
using SIO.Domain.Notifications.Events;
using SIO.Testing.Abstractions;
using SIO.Testing.Attributes;

namespace SIO.Domain.Tests.Notifications.Aggregates.Notification
{
    public class WhenWindowsNotificaitonQueued : AggregateSpecification<Domain.Notifications.Aggregates.Notification, NotificationState>
    {
        private readonly Guid _aggregateId = Guid.NewGuid().ToSequentialGuid();
        private readonly string _payload = "Test payload";
        private readonly string _template = "Test template";
        private readonly IEnumerable<string> _tags = new string[] { Guid.NewGuid().ToSequentialGuid().ToString() };
        protected override IEnumerable<IEvent> Given()
        {
            yield break;
        }

        protected override void When()
        {
            Aggregate.QueueForWindows(_aggregateId, _payload, _template, _tags);
        }

        [Then]
        public void ShouldContainOneUncommitedEvent()
        {
            Aggregate.GetUncommittedEvents().Should().HaveCount(1);
        }

        [Then]
        public void ShouldContainUncommitedWindowsNotificationQueuedEventWithCorrectAggregateId()
        {
            var events = Aggregate.GetUncommittedEvents();

            var @event = events.OfType<WindowsNotificationQueued>().Single();

            @event.AggregateId.Should().Be(_aggregateId);
        }

        [Then]
        public void ShouldContainUncommitedWindowsNotificationQueuedEvent()
        {
            var events = Aggregate.GetUncommittedEvents();

            events.Single().Should().BeOfType<WindowsNotificationQueued>();
        }

        [Then]
        public void ShouldContainUncommitedWindowsNotificationQueuedEventWithCorrectPayload()
        {
            var events = Aggregate.GetUncommittedEvents();

            var @event = events.OfType<WindowsNotificationQueued>().Single();

            @event.Payload.Should().Be(_payload);
        }

        [Then]
        public void ShouldContainUncommitedWindowsNotificationQueuedEventWithCorrectTemplate()
        {
            var events = Aggregate.GetUncommittedEvents();
            var @event = events.OfType<WindowsNotificationQueued>().Single();

            @event.Template.Should().Be(_template);
        }

        [Then]
        public void ShouldContainUncommitedWindowsNotificationQueuedEventWithCorrectTags()
        {
            var events = Aggregate.GetUncommittedEvents();
            var @event = events.OfType<WindowsNotificationQueued>().Single();

            @event.Tags.Should().BeEquivalentTo(_tags);
        }

        [Then]
        public void ShouldContainUncommitedWindowsNotificationQueuedEventWithCorrectVersion()
        {
            var events = Aggregate.GetUncommittedEvents();
            var @event = events.OfType<WindowsNotificationQueued>().Single();

            @event.Version.Should().Be(1);
        }

        [Then]
        public void ShouldContainAggregateWithCorrectId()
        {
            Aggregate.Id.Should().Be(_aggregateId);
        }

        [Then]
        public void ShouldContainAggregateWithCorrectVersion()
        {
            Aggregate.Version.Should().Be(1);
        }

        [Then]
        public void ShouldContainStateWithCorrectPayload()
        {
            Aggregate.GetState().Payload.Should().Be(_payload);
        }

        [Then]
        public void ShouldContainStateWithCorrectTemplate()
        {
            Aggregate.GetState().Template.Should().Be(_template);
        }

        [Then]
        public void ShouldContainStateWithCorrectTags()
        {
            Aggregate.GetState().Tags.Should().BeEquivalentTo(_tags);
        }

        [Then]
        public void ShouldContainStateWithCorrectStatus()
        {
            Aggregate.GetState().Status.Should().Be(NotificationStatus.Pending);
        }

        [Then]
        public void ShouldContainStateWithCorrectType()
        {
            Aggregate.GetState().Type.Should().Be(NotificationType.Windows);
        }

        [Then]
        public void ShouldContainStateWithCorrectAttempts()
        {
            Aggregate.GetState().Attempts.Should().Be(0);
        }
    }
}
