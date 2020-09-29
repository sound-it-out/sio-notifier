using System;
using OpenEventSourcing.Events;

namespace SIO.Domain.Notifications.Events
{
    public class NotificationFailed : Event
    {
        public string Error { get; set; }

        public NotificationFailed(Guid aggregateId, int version, string error) : base(aggregateId, version)
        {
            Error = error;
        }
    }
}
