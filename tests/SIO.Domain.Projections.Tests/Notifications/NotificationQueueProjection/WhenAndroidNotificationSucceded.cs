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
    public class WhenAndroidNotificationSucceded : ProjectionSpecification<Projections.Notifications.NotificationQueueProjection>
    {
        private readonly Guid _aggregateId = Guid.NewGuid().ToSequentialGuid();
        private readonly string _template = "Test template";
        private readonly string _payload = "Test payload";
        private readonly IEnumerable<string> _tags = new string[] { Guid.NewGuid().ToSequentialGuid().ToString() };

        protected override IEnumerable<IEvent> Given()
        {
            yield return new AndroidNotificationQueued(_aggregateId, 1, _template, _payload, _tags);
            yield return new NotificationSucceded(_aggregateId, 2);
        }

        [Then]
        public void NotificaionShouldBeNull()
        {
            var notification = Context.Find<NotificationQueue>(_aggregateId);
            notification.Should().BeNull();
        }
    }
}
