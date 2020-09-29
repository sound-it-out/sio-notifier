using System;
using System.Linq;
using System.Threading.Tasks;
using OpenEventSourcing.Commands;
using OpenEventSourcing.Domain;
using OpenEventSourcing.Events;
using SIO.Domain.Notifications.Aggregates;
using SIO.Domain.Notifications.Builders;
using SIO.Domain.Notifications.Commands;
using SIO.Infrastructure.Notifications.Processors;

namespace SIO.Domain.Notifications.CommandHandlers
{
    public class ProcessAndroidNotificationCommandHandler : ICommandHandler<ProcessAndroidNotificationCommand>
    {
        private readonly IAggregateRepository _aggregateRepository;
        private readonly IAndroidNotificationProcessor _androidNotificationProcessor;
        private readonly IEventBusPublisher _eventBusPublisher;
        private readonly IAndroidNotificationMessageBuilder _androidNotificationMessageBuilder;

        public ProcessAndroidNotificationCommandHandler(IAggregateRepository aggregateRepository,
            IAndroidNotificationProcessor androidNotificationProcessor,
            IEventBusPublisher eventBusPublisher,
            IAndroidNotificationMessageBuilder androidNotificationMessageBuilder)
        {
            if (aggregateRepository == null)
                throw new ArgumentNullException(nameof(aggregateRepository));
            if (androidNotificationProcessor == null)
                throw new ArgumentNullException(nameof(androidNotificationProcessor));
            if (eventBusPublisher == null)
                throw new ArgumentNullException(nameof(eventBusPublisher));
            if (androidNotificationMessageBuilder == null)
                throw new ArgumentNullException(nameof(androidNotificationMessageBuilder));

            _aggregateRepository = aggregateRepository;
            _androidNotificationProcessor = androidNotificationProcessor;
            _eventBusPublisher = eventBusPublisher;
            _androidNotificationMessageBuilder = androidNotificationMessageBuilder;
        }
        public async Task ExecuteAsync(ProcessAndroidNotificationCommand command)
        {
            var aggregate = await _aggregateRepository.GetAsync<Notification, NotificationState>(command.AggregateId);

            try
            {
                var message = await _androidNotificationMessageBuilder.BuildAsync(aggregate.GetState());
                await _androidNotificationProcessor.ProcessAsync(message, aggregate.GetState().Tags);

                aggregate.MarkAsSuccess();
            }
            catch (Exception e)
            {
                aggregate.MarkAsFail(e.Message);
            }

            var events = aggregate.GetUncommittedEvents();

            foreach (var @event in events)
                @event.UpdateFrom(command);

            events = events.ToList();

            await _aggregateRepository.SaveAsync(aggregate, 0);
            await _eventBusPublisher.PublishAsync(events);
        }
    }
}
