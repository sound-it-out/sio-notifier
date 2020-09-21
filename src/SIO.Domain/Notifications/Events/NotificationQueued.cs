using System;
using OpenEventSourcing.Events;

namespace SIO.Domain.Notifications.Events
{
    public class NotificationQueued : Event
    {
        public NotificationQueued(Guid aggregateId, int version) : base(aggregateId, version)
        {
        }
    }
}
