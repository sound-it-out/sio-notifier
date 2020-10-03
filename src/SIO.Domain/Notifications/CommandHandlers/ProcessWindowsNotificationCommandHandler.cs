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
    public class ProcessWindowsNotificationCommandHandler : ICommandHandler<ProcessWindowsNotificationCommand>
    {
        private readonly IAggregateRepository _aggregateRepository;
        private readonly IWindowsNotificationProcessor _windowsNotificationProcessor;
        private readonly IEventBusPublisher _eventBusPublisher;
        private readonly IWindowsNotificationMessageBuilder _windowsNotificationMessageBuilder;

        public ProcessWindowsNotificationCommandHandler(IAggregateRepository aggregateRepository,
            IWindowsNotificationProcessor windowsNotificationProcessor,
            IEventBusPublisher eventBusPublisher,
            IWindowsNotificationMessageBuilder windowsNotificationMessageBuilder)
        {
            if (aggregateRepository == null)
                throw new ArgumentNullException(nameof(aggregateRepository));
            if (windowsNotificationProcessor == null)
                throw new ArgumentNullException(nameof(windowsNotificationProcessor));
            if (eventBusPublisher == null)
                throw new ArgumentNullException(nameof(eventBusPublisher));
            if (windowsNotificationMessageBuilder == null)
                throw new ArgumentNullException(nameof(windowsNotificationMessageBuilder));

            _aggregateRepository = aggregateRepository;
            _windowsNotificationProcessor = windowsNotificationProcessor;
            _eventBusPublisher = eventBusPublisher;
            _windowsNotificationMessageBuilder = windowsNotificationMessageBuilder;
        }
        public async Task ExecuteAsync(ProcessWindowsNotificationCommand command)
        {
            var aggregate = await _aggregateRepository.GetAsync<Notification, NotificationState>(command.AggregateId);

            try
            {
                var message = await _windowsNotificationMessageBuilder.BuildAsync(aggregate.GetState());
                await _windowsNotificationProcessor.ProcessAsync(message, aggregate.GetState().Tags);

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
