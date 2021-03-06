﻿using System;
using Newtonsoft.Json;
using OpenEventSourcing.Events;

namespace SIO.Domain.Translation.Events
{
    public class TranslationSucceded : Event
    {
        public TranslationSucceded(Guid aggregateId, int version) : base(aggregateId, version)
        {
        }

        [JsonConstructor]
        public TranslationSucceded(Guid aggregateId, Guid correlationId, Guid userId, int version) : base(aggregateId, version)
        {
            CorrelationId = correlationId;
            UserId = userId.ToString();
        }
    }
}
