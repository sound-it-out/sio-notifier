using System;
using OpenEventSourcing.Commands;

namespace SIO.Domain.Notifications.Commands
{
    public class ProcessAndroidNotificationCommand : Command
    {
        public ProcessAndroidNotificationCommand(Guid aggregateId, Guid correlationId, int version, string userId) : base(aggregateId, correlationId, version, userId)
        {
        }
    }
}
