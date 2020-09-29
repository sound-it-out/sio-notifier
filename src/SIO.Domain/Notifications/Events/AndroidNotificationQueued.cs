using System;
using System.Collections.Generic;
using OpenEventSourcing.Events;

namespace SIO.Domain.Notifications.Events
{
    public class AndroidNotificationQueued : Event
    {
        public string Template { get; set; }
        public string Payload { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public AndroidNotificationQueued(Guid aggregateId, int version, string template, string payload, IEnumerable<string> tags) : base(aggregateId, version)
        {
            Template = template;
            Payload = payload;
            Tags = tags;
        }
    }
}
