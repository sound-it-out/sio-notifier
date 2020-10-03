using System;
using OpenEventSourcing.Commands;

namespace SIO.Domain.Notifications.Commands
{
    public class QueueIosNotificationCommand : Command
    {
        public string Payload { get; set; }
        public string Template { get; set; }

        public QueueIosNotificationCommand(Guid aggregateId, Guid correlationId, string userId, string payload, string template) : base(aggregateId, correlationId, 0, userId)
        {
            Payload = payload;
            Template = template;
        }
    }
}
