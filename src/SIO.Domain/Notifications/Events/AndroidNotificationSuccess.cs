﻿using System;
using OpenEventSourcing.Commands;
using OpenEventSourcing.Events;
using OpenEventSourcing.Extensions;

namespace SIO.Domain.Notifications.Events
{
    public class AndroidNotificationSuccess : IEvent
    {
        public Guid Id { get; }
        public Guid AggregateId { get; }
        public Guid? CorrelationId { get; }
        public Guid? CausationId { get; }
        public DateTimeOffset Timestamp { get; }
        public int Version { get; }
        public string UserId { get; }

        public AndroidNotificationSuccess(Guid aggregateId, int version, Guid? correlationId, Guid? causationId, string userId)
        {
            Id = Guid.NewGuid().ToSequentialGuid();
            AggregateId = aggregateId;
            CorrelationId = correlationId;
            CausationId = causationId;
            Timestamp = DateTimeOffset.UtcNow;
            Version = version;
            UserId = userId;
        }

        public void UpdateFrom(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
