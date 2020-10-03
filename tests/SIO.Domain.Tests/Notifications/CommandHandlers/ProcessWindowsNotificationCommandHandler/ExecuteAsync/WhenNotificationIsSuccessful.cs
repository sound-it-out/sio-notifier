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

namespace SIO.Domain.Tests.Notifications.CommandHandlers.ProcessWindowsNotificationCommandHandler.ExecuteAsync
{
    public class WhenNotificationIsSuccessful : CommandHandlerSpecification<ProcessWindowsNotificationCommand>
    {
        private readonly Guid _aggregateId = Guid.NewGuid().ToSequentialGuid();
        private readonly Guid _correlationId = Guid.NewGuid().ToSequentialGuid();
        private readonly string _userId = Guid.NewGuid().ToSequentialGuid().ToString();
        private readonly string _payload = "Test payload";
        private readonly string _template = "Test template";

        protected override void BuildServices(IServiceCollection services)
        {
            base.BuildServices(services);

            services.RemoveAll<IWindowsNotificationMessageBuilder>();
            services.AddSingleton<IWindowsNotificationMessageBuilder, FakeWindowsNotificationMessageBuilder>();
            services.AddSingleton<IWindowsNotificationProcessor>(new FakeWindowsNotificationProcessor(false, ""));
        }

        protected override ProcessWindowsNotificationCommand Given()
        {
            return new ProcessWindowsNotificationCommand(_aggregateId, _correlationId, 1, _userId);
        }

        protected override async Task When()
        {
            await _commandDispatcher.DispatchAsync(new QueueAndroidNotificationCommand(_aggregateId, _correlationId, _userId, _payload, _template));
        }

        [Then]
        public async Task NotificationSuccededEventShouldBeCreated()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();

            using(var context = contextFactory.Create())
            {
                var @event = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                @event.Type = typeof(NotificationSucceded).AssemblyQualifiedName;
            }
        }

        [Then]
        public async Task NotificationSuccededEventShouldBeCreatedWithCorrectAggregateId()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                var @event = eventDeserializer.Deserialize<NotificationSucceded>(eventEntity.Data);
                @event.AggregateId.Should().Be(_aggregateId);
            }
        }

        [Then]
        public async Task NotificationSuccededEventShouldBeCreatedWithCorrectCorrelationId()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                var @event = eventDeserializer.Deserialize<NotificationSucceded>(eventEntity.Data);
                @event.CorrelationId.Should().Be(_correlationId);
            }
        }

        [Then]
        public async Task NotificationSuccededEventShouldBeCreatedWithCorrectUserId()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                var @event = eventDeserializer.Deserialize<NotificationSucceded>(eventEntity.Data);
                @event.UserId.Should().Be(_userId);
            }
        }

        [Then]
        public async Task NotificationSuccededEventShouldBeCreatedWithCorrectVersion()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).LastAsync();
                var test = await context.Events.ToArrayAsync();
                var @event = eventDeserializer.Deserialize<NotificationSucceded>(eventEntity.Data);
                @event.Version.Should().Be(2);
            }
        }

        [Then]
        public void NotificationSuccededEventShouldBePublished()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            eventPublisher.Events.First().Should().BeOfType<NotificationSucceded>();
        }

        [Then]
        public void NotificationSuccededEventShouldBePublishedWithCorrectAggregateId()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (NotificationSucceded)eventPublisher.Events.First();
            @event.AggregateId.Should().Be(_aggregateId);
        }

        [Then]
        public void NotificationSuccededEventShouldBePublishedWithCorrectCorrelationId()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (NotificationSucceded)eventPublisher.Events.First();
            @event.CorrelationId.Should().Be(_correlationId);
        }

        [Then]
        public void NotificationSuccededEventShouldBePublishedWithCorrectUserId()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (NotificationSucceded)eventPublisher.Events.First();
            @event.UserId.Should().Be(_userId);
        }

        [Then]
        public void NotificationSuccededEventShouldBePublishedWithCorrectVersion()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (NotificationSucceded)eventPublisher.Events.First();
            @event.Version.Should().Be(2);
        }
    }
}
