using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using OpenEventSourcing.Events;
using OpenEventSourcing.Extensions;
using SIO.Domain.Notifications.Events;
using SIO.Domain.Notifications.Projections;
using SIO.Testing.Abstractions;
using SIO.Testing.Attributes;

namespace SIO.Domain.Projections.Tests.Notifications.NotificationFailureProjection
{
    public class WhenNotificationFailed : ProjectionSpecification<Projections.Notifications.NotificationFailureProjection>
    {
        private readonly Guid _aggregateId = Guid.NewGuid().ToSequentialGuid();
        private readonly string _error = "Test error";

        protected override IEnumerable<IEvent> Given()
        {
            yield return new NotificationFailed(_aggregateId, 0, _error);
        }

        [Then]
        public void NotificaionShouldNotBeNull()
        {
            var notification = Context.Set<NotificationFailure>().Where(nf => nf.NotificationId == _aggregateId).FirstOrDefault();
            notification.Should().NotBeNull();
        }

        [Then]
        public void NotificaionIdShouldNotBeNull()
        {
            var notification = Context.Set<NotificationFailure>().Where(nf => nf.NotificationId == _aggregateId).FirstOrDefault();
            notification.Id.Should().NotBeEmpty();
        }

        [Then]
        public void NotificaionShouldHaveCorrectNotificationId()
        {
            var notification = Context.Set<NotificationFailure>().Where(nf => nf.NotificationId == _aggregateId).FirstOrDefault();
            notification.NotificationId.Should().Be(_aggregateId);
        }

        [Then]
        public void NotificaionShouldHaveCorrectError()
        {
            var notification = Context.Set<NotificationFailure>().Where(nf => nf.NotificationId == _aggregateId).FirstOrDefault();
            notification.Error.Should().Be(_error);
        }
    }
}
