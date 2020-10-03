using System;
using System.Collections.Generic;
using System.Text;
using OpenEventSourcing.Domain;

namespace SIO.Domain.Notifications.Aggregates
{
    public class NotificationState : IAggregateState
    {
        public int Attempts { get; set; }
        public string Payload { get; set; }
        public string Template { get; set; }
        public NotificationStatus Status { get; set; }
        public NotificationType Type { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public NotificationState()
        {
            Tags = new List<string>();
        }

        public NotificationState(NotificationState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            Attempts = state.Attempts;
            Payload = state.Payload;
            Template = state.Template;
            Status = state.Status;
            Type = state.Type;
            Tags = state.Tags;
        }
    }
}
