﻿using System;
using System.Threading.Tasks;
using OpenEventSourcing.Commands;
using OpenEventSourcing.Events;
using OpenEventSourcing.Serialization;
using SIO.Domain.Notifications.Commands;
using SIO.Domain.Translation.Events;

namespace SIO.Domain.Translation.EventHandlers
{
    public class TranslationSuccededEventHandler : IEventHandler<TranslationSucceded>
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IEventSerializer _eventSerializer;

        public TranslationSuccededEventHandler(ICommandDispatcher commandDispatcher, IEventSerializer eventSerializer)
        {
            if (commandDispatcher == null)
                throw new ArgumentNullException(nameof(commandDispatcher));
            if (eventSerializer == null)
                throw new ArgumentNullException(nameof(eventSerializer));

            _commandDispatcher = commandDispatcher;
            _eventSerializer = eventSerializer;
        }

        public async Task HandleAsync(TranslationSucceded @event)
        {
            await _commandDispatcher.DispatchAsync(new QueueNotificationCommand(aggregateId: Guid.NewGuid(),
                correlationId: @event.Id,
                version: 0,
                userId: @event.UserId,
                payload: _eventSerializer.Serialize(@event),
                template: nameof(TranslationSucceded))
            );
        }
    }
}
