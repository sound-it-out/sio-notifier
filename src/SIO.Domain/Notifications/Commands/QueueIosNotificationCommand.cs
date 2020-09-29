using System;
using OpenEventSourcing.Commands;

namespace SIO.Domain.Notifications.Commands
{
    public class QueueIosNotificationCommand : Command
    {
        public string Payload { get; set; }
        public string Template { get; set; }

        public QueueIosNotificationCommand(Guid aggregateId, Guid correlationId, int version, string userId, string payload, string template) : base(aggregateId, correlationId, version, userId)
        {
            Payload = payload;
            Template = template;
        }
    }
}
