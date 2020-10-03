using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenEventSourcing.EntityFrameworkCore.DbContexts;
using OpenEventSourcing.Events;
using OpenEventSourcing.Extensions;
using OpenEventSourcing.Serialization;
using SIO.Domain.Notifications.Commands;
using SIO.Domain.Notifications.Events;
using SIO.Testing.Abstractions;
using SIO.Testing.Attributes;
using SIO.Testing.Fakes.Events;

namespace SIO.Domain.Tests.Notifications.CommandHandlers.QueueWindowsNotificationCommandHandler.ExecuteAsync
{
    public class WhenExecuted : CommandHandlerSpecification<QueueWindowsNotificationCommand>
    {
        private readonly Guid _aggregateId = Guid.NewGuid().ToSequentialGuid();
        private readonly Guid _correlationId = Guid.NewGuid().ToSequentialGuid();
        private readonly string _userId = Guid.NewGuid().ToSequentialGuid().ToString();
        private readonly string _payload = "Test payload";
        private readonly string _template = "Test template";
        private IEnumerable<string> Tags => new string[] { _userId };

        protected override QueueWindowsNotificationCommand Given()
        {
            return new QueueWindowsNotificationCommand(_aggregateId, _correlationId, _userId, _payload, _template);
        }

        protected override Task When()
        {
            return Task.CompletedTask;
        }

        [Then]
        public async Task WindowsNotificationQueuedEventShouldBeCreated()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();

            using(var context = contextFactory.Create())
            {
                var @event = await context.Events.Where(e => e.AggregateId == _aggregateId).FirstOrDefaultAsync();
                @event.Type = typeof(WindowsNotificationQueued).AssemblyQualifiedName;
            }
        }

        [Then]
        public async Task WindowsNotificationQueuedEventShouldBeCreatedWithCorrectAggregateId()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).FirstOrDefaultAsync();
                var @event = eventDeserializer.Deserialize<WindowsNotificationQueued>(eventEntity.Data);
                @event.AggregateId.Should().Be(_aggregateId);
            }
        }

        [Then]
        public async Task WindowsNotificationQueuedEventShouldBeCreatedWithCorrectCorrelationId()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).FirstOrDefaultAsync();
                var @event = eventDeserializer.Deserialize<WindowsNotificationQueued>(eventEntity.Data);
                @event.CorrelationId.Should().Be(_correlationId);
            }
        }

        [Then]
        public async Task WindowsNotificationQueuedEventShouldBeCreatedWithCorrectUserId()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).FirstOrDefaultAsync();
                var @event = eventDeserializer.Deserialize<WindowsNotificationQueued>(eventEntity.Data);
                @event.UserId.Should().Be(_userId);
            }
        }

        [Then]
        public async Task WindowsNotificationQueuedEventShouldBeCreatedWithCorrectPayload()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).FirstOrDefaultAsync();
                var @event = eventDeserializer.Deserialize<WindowsNotificationQueued>(eventEntity.Data);
                @event.Payload.Should().Be(_payload);
            }
        }

        [Then]
        public async Task WindowsNotificationQueuedEventShouldBeCreatedWithCorrectTemplate()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).FirstOrDefaultAsync();
                var @event = eventDeserializer.Deserialize<WindowsNotificationQueued>(eventEntity.Data);
                @event.Template.Should().Be(_template);
            }
        }

        [Then]
        public async Task WindowsNotificationQueuedEventShouldBeCreatedWithCorrectTags()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).FirstOrDefaultAsync();
                var @event = eventDeserializer.Deserialize<WindowsNotificationQueued>(eventEntity.Data);
                @event.Tags.Should().BeEquivalentTo(Tags);
            }
        }

        [Then]
        public async Task WindowsNotificationQueuedEventShouldBeCreatedWithCorrectVersion()
        {
            var contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory>();
            var eventDeserializer = _serviceProvider.GetRequiredService<IEventDeserializer>();

            using (var context = contextFactory.Create())
            {
                var eventEntity = await context.Events.Where(e => e.AggregateId == _aggregateId).FirstOrDefaultAsync();
                var @event = eventDeserializer.Deserialize<WindowsNotificationQueued>(eventEntity.Data);
                @event.Version.Should().Be(1);
            }
        }

        [Then]
        public void WindowsNotificationQueuedEventShouldBePublished()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            eventPublisher.Events.First().Should().BeOfType<WindowsNotificationQueued>();
        }

        [Then]
        public void WindowsNotificationQueuedEventShouldBePublishedWithCorrectAggregateId()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (WindowsNotificationQueued)eventPublisher.Events.First();
            @event.AggregateId.Should().Be(_aggregateId);
        }

        [Then]
        public void WindowsNotificationQueuedEventShouldBePublishedWithCorrectCorrelationId()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (WindowsNotificationQueued)eventPublisher.Events.First();
            @event.CorrelationId.Should().Be(_correlationId);
        }

        [Then]
        public void WindowsNotificationQueuedEventShouldBePublishedWithCorrectUserId()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (WindowsNotificationQueued)eventPublisher.Events.First();
            @event.UserId.Should().Be(_userId);
        }

        [Then]
        public void WindowsNotificationQueuedEventShouldBePublishedWithCorrectPayload()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (WindowsNotificationQueued)eventPublisher.Events.First();
            @event.Payload.Should().Be(_payload);
        }

        [Then]
        public void WindowsNotificationQueuedEventShouldBePublishedWithCorrectTemplate()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (WindowsNotificationQueued)eventPublisher.Events.First();
            @event.Template.Should().Be(_template);
        }

        [Then]
        public void WindowsNotificationQueuedEventShouldBePublishedWithCorrectTags()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (WindowsNotificationQueued)eventPublisher.Events.First();
            @event.Tags.Should().BeEquivalentTo(Tags);
        }

        [Then]
        public void WindowsNotificationQueuedEventShouldBePublishedWithCorrectVersion()
        {
            var eventPublisher = (FakeEventBusPublisher)_serviceProvider.GetRequiredService<IEventBusPublisher>();
            var @event = (WindowsNotificationQueued)eventPublisher.Events.First();
            @event.Version.Should().Be(1);
        }
    }
}
