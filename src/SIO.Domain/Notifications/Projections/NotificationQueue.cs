using System;
using System.Collections.Generic;

namespace SIO.Domain.Notifications.Projections
{
    public class NotificationQueue
    {
        public Guid Id { get; set; }
        public int Attempts { get; set; }
        public NotificationStatus Status { get; set; }
        public NotificationType Type { get; set; }
        public string Template { get; set; }
        public string Payload { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public int Version { get; set; }
    }
}
