using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenEventSourcing.EntityFrameworkCore.DbContexts;
using OpenEventSourcing.Events;
using OpenEventSourcing.Extensions;
using OpenEventSourcing.Serialization;
using SIO.Domain.Notifications.Builders;
using SIO.Domain.Notifications.Commands;
using SIO.Domain.Notifications.Events;
using SIO.Infrastructure.Notifications.Processors;
using SIO.Testing.Abstractions;
using SIO.Testing.Attributes;
using SIO.Testing.Fakes.Events;
using SIO.Testing.Fakes.Notifications.Builders;

namespace SIO.Domain.Tests.Notifications.CommandHandlers.ProcessIosNotificationCommandHandler.ExecuteAsync
{
    public class WhenNotificationIsNotSuccessful : CommandHandlerSpecification<ProcessIosNotificationCommand>
    {
        private readonly Guid _aggregateId = Guid.NewGuid().ToSequentialGuid();
        private readonly Guid _correlationId = Guid.NewGuid().ToSequentialGuid();
        private readonly string _userId = Guid.NewGuid().ToSequentialGuid().ToString();
        private readonly string _payload = "Test payload";
        private readonly string _template = "Test template";
        private readonly string _exception = "Test exception";

        protected override void BuildServices(IServiceCollection services)
        {
            base.BuildServices(services);

            services.RemoveAll<IIosNotificationMessageBuilder>();
            services.AddSingleton<IIosNotificationMessageBuilder, FakeIosNotificationMessageBuilder>();
            services.AddSingleton<IIosNotificationProcessor>(new FakeIosNotificationProcessor(true, _exception));
        }

        protected override ProcessIosNotificationCommand Given()
        {
            return new ProcessIosNotificationCommand(_aggregateId, _correlationId, 1, _userId);
        }

        protected override async Task When()
        {
            await _commandDispatcher.DispatchAsync(new QueueAndroidNotificationCommand(_aggregateId, _correlationId, _userId, _payload, _template));
        }

        [Then]
        public async Task NotificationFailedEventShouldBeCreated()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();

            using(var context = contextFactory.Create())
            {
                var @event = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                @event.Type = typeof(NotificationFailed).AssemblyQualifiedName;
            }
        }

        [Then]
        public async Task NotificationFailedEventShouldBeCreatedWithCorrectAggregateId()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                var @event = eventDeserializer.Deserialize<NotificationFailed>(eventEntity.Data);
                @event.AggregateId.Should().Be(_aggregateId);
            }
        }

        [Then]
        public async Task NotificationFailedEventShouldBeCreatedWithCorrectCorrelationId()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                var @event = eventDeserializer.Deserialize<NotificationFailed>(eventEntity.Data);
                @event.CorrelationId.Should().Be(_correlationId);
            }
        }

        [Then]
        public async Task NotificationFailedEventShouldBeCreatedWithCorrectUserId()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                var @event = eventDeserializer.Deserialize<NotificationFailed>(eventEntity.Data);
                @event.UserId.Should().Be(_userId);
            }
        }

        [Then]
        public async Task NotificationFailedEventShouldBeCreatedWithCorrectError()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                var @event = eventDeserializer.Deserialize<NotificationFailed>(eventEntity.Data);
                @event.Error.Should().Be(_exception);
            }
        }

        [Then]
        public async Task NotificationFailedEventShouldBeCreatedWithCorrectVersion()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                var @event = eventDeserializer.Deserialize<NotificationFailed>(eventEntity.Data);
                @event.Version.Should().Be(2);
            }
        }

        [Then]
        public void NotificationFailedEventShouldBePublished()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            eventPublisher.Events.First().Should().BeOfType<NotificationFailed>();
        }

        [Then]
        public void NotificationFailedEventShouldBePublishedWithCorrectAggregateId()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (NotificationFailed)eventPublisher.Events.First();
            @event.AggregateId.Should().Be(_aggregateId);
        }

        [Then]
        public void NotificationFailedEventShouldBePublishedWithCorrectCorrelationId()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (NotificationFailed)eventPublisher.Events.First();
            @event.CorrelationId.Should().Be(_correlationId);
        }

        [Then]
        public void NotificationFailedEventShouldBePublishedWithCorrectUserId()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (NotificationFailed)eventPublisher.Events.First();
            @event.UserId.Should().Be(_userId);
        }

        [Then]
        public void NotificationFailedEventShouldBePublishedWithCorrectError()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (NotificationFailed)eventPublisher.Events.First();
            @event.Error.Should().Be(_exception);
        }

        [Then]
        public void NotificationFailedEventShouldBePublishedWithCorrectVersion()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (NotificationFailed)eventPublisher.Events.First();
            @event.Version.Should().Be(2);
        }
    }
}
