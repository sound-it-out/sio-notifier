using System;
using OpenEventSourcing.Events;

namespace SIO.Domain.Notifications.Events
{
    public class NotificationSucceded : Event
    {
        public NotificationSucceded(Guid aggregateId, int version) : base(aggregateId, version)
        {
        }
    }
}
