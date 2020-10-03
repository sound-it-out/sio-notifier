using System;
using System.Linq;
using System.Threading.Tasks;
using OpenEventSourcing.Commands;
using OpenEventSourcing.Domain;
using OpenEventSourcing.Events;
using SIO.Domain.Notifications.Aggregates;
using SIO.Domain.Notifications.Commands;

namespace SIO.Domain.Notifications.CommandHandlers
{
    internal class QueueIosNotificationCommandHandler : ICommandHandler<QueueIosNotificationCommand>
    {
        private readonly IAggregateRepository _aggregateRepository;
        private readonly IAggregateFactory _aggregateFactory;
        private readonly IEventBusPublisher _eventBusPublisher;

        public QueueIosNotificationCommandHandler(IAggregateRepository aggregateRepository,
            IAggregateFactory aggregateFactory,
            IEventBusPublisher eventBusPublisher)
        {
            if (aggregateRepository == null)
                throw new ArgumentNullException(nameof(aggregateRepository));
            if (aggregateFactory == null)
                throw new ArgumentNullException(nameof(aggregateFactory));
            if (eventBusPublisher == null)
                throw new ArgumentNullException(nameof(eventBusPublisher));

            _aggregateRepository = aggregateRepository;
            _aggregateFactory = aggregateFactory;
            _eventBusPublisher = eventBusPublisher;
        }

        public async Task ExecuteAsync(QueueIosNotificationCommand command)
        {
            var aggregate = _aggregateFactory.FromHistory<Notification, NotificationState>(Enumerable.Empty<IEvent>());

            if (aggregate == null)
                throw new ArgumentNullException(nameof(aggregate));

            aggregate.QueueForIos(aggregateId: command.AggregateId,
                payload: command.Payload,
                template: command.Template,
                tags: new string[1] { command.UserId });

            var events = aggregate.GetUncommittedEvents();

            foreach (var @event in events)
                @event.UpdateFrom(command);

            events = events.ToList();

            await _aggregateRepository.SaveAsync(aggregate, command.Version);
            await _eventBusPublisher.PublishAsync(events);
        }
    }
}
