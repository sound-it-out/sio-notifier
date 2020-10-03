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
    public class ProcessIosNotificationCommandHandler : ICommandHandler<ProcessIosNotificationCommand>
    {
        private readonly IAggregateRepository _aggregateRepository;
        private readonly IIosNotificationProcessor _iosNotificationProcessor;
        private readonly IEventBusPublisher _eventBusPublisher;
        private readonly IIosNotificationMessageBuilder _iosNotificationMessageBuilder;

        public ProcessIosNotificationCommandHandler(IAggregateRepository aggregateRepository,
            IIosNotificationProcessor iosNotificationProcessor,
            IEventBusPublisher eventBusPublisher,
            IIosNotificationMessageBuilder iosNotificationMessageBuilder)
        {
            if (aggregateRepository == null)
                throw new ArgumentNullException(nameof(aggregateRepository));
            if (iosNotificationProcessor == null)
                throw new ArgumentNullException(nameof(iosNotificationProcessor));
            if (eventBusPublisher == null)
                throw new ArgumentNullException(nameof(eventBusPublisher));
            if (iosNotificationMessageBuilder == null)
                throw new ArgumentNullException(nameof(iosNotificationMessageBuilder));

            _aggregateRepository = aggregateRepository;
            _iosNotificationProcessor = iosNotificationProcessor;
            _eventBusPublisher = eventBusPublisher;
            _iosNotificationMessageBuilder = iosNotificationMessageBuilder;
        }
        public async Task ExecuteAsync(ProcessIosNotificationCommand command)
        {
            var aggregate = await _aggregateRepository.GetAsync<Notification, NotificationState>(command.AggregateId);

            try
            {
                var message = await _iosNotificationMessageBuilder.BuildAsync(aggregate.GetState());
                await _iosNotificationProcessor.ProcessAsync(message, aggregate.GetState().Tags);

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

            await _aggregateRepository.SaveAsync(aggregate, command.Version);
            await _eventBusPublisher.PublishAsync(events);
        }
    }
}
