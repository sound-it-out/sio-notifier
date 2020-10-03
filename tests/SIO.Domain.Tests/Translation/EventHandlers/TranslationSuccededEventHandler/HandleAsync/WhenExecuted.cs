using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using OpenEventSourcing.Commands;
using OpenEventSourcing.Extensions;
using OpenEventSourcing.Serialization;
using SIO.Domain.Notifications.Commands;
using SIO.Domain.Tests.Notifications.Notifiers;
using SIO.Domain.Translation.Events;
using SIO.Testing.Abstractions;
using SIO.Testing.Attributes;

namespace SIO.Domain.Tests.Translation.EventHandlers.TranslationSuccededEventHandler.HandleAsync
{
    public class WhenExecuted : EventHandlerSpecification<TranslationSucceded>
    {
        private readonly TranslationSucceded _event = new TranslationSucceded(Guid.NewGuid().ToSequentialGuid(), Guid.NewGuid().ToSequentialGuid(), Guid.NewGuid().ToSequentialGuid(), 2);
        protected override TranslationSucceded Given()
        {
            return _event;
        }

        protected override Task When()
        {
            return Task.CompletedTask;
        }

        [Then]
        public void QueueAndroidNotificationCommandShouldBeDispatched()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            commandDispatcher.Commands.Count(c => c.GetType() == typeof(QueueAndroidNotificationCommand)).Should().Be(1);
        }

        [Then]
        public void QueueAndroidNotificationCommandShouldBeDispatchedWithCorrectCorrelationId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (QueueAndroidNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueAndroidNotificationCommand));
            command.CorrelationId.Should().Be(_event.Id);
        }

        [Then]
        public void QueueAndroidNotificationCommandShouldBeDispatchedWithCorrectUserId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (QueueAndroidNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueAndroidNotificationCommand));
            command.UserId.Should().Be(_event.UserId);
        }

        [Then]
        public void QueueAndroidNotificationCommandShouldBeDispatchedWithCorrectPayload()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var eventSerializer = _serviceProvider.GetRequiredService<IEventSerializer>();
            var command = (QueueAndroidNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueAndroidNotificationCommand));
            command.Payload.Should().Be(eventSerializer.Serialize(_event));
        }

        [Then]
        public void QueueAndroidNotificationCommandShouldBeDispatchedWithCorrectTemplate()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (QueueAndroidNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueAndroidNotificationCommand));
            command.Template.Should().Be(nameof(TranslationSucceded));
        }

        [Then]
        public void QueueIosNotificationCommandShouldBeDispatched()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            commandDispatcher.Commands.Count(c => c.GetType() == typeof(QueueIosNotificationCommand)).Should().Be(1);
        }

        [Then]
        public void QueueIosNotificationCommandShouldBeDispatchedWithCorrectCorrelationId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (QueueIosNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueIosNotificationCommand));
            command.CorrelationId.Should().Be(_event.Id);
        }

        [Then]
        public void QueueIosNotificationCommandShouldBeDispatchedWithCorrectUserId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (QueueIosNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueIosNotificationCommand));
            command.UserId.Should().Be(_event.UserId);
        }

        [Then]
        public void QueueIosNotificationCommandShouldBeDispatchedWithCorrectPayload()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var eventSerializer = _serviceProvider.GetRequiredService<IEventSerializer>();
            var command = (QueueIosNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueIosNotificationCommand));
            command.Payload.Should().Be(eventSerializer.Serialize(_event));
        }

        [Then]
        public void QueueIosNotificationCommandShouldBeDispatchedWithCorrectTemplate()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (QueueIosNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueIosNotificationCommand));
            command.Template.Should().Be(nameof(TranslationSucceded));
        }

        [Then]
        public void QueueWindowsNotificationCommandShouldBeDispatched()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            commandDispatcher.Commands.Count(c => c.GetType() == typeof(QueueWindowsNotificationCommand)).Should().Be(1);
        }

        [Then]
        public void QueueWindowsNotificationCommandShouldBeDispatchedWithCorrectCorrelationId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (QueueWindowsNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueWindowsNotificationCommand));
            command.CorrelationId.Should().Be(_event.Id);
        }

        [Then]
        public void QueueWindowsNotificationCommandShouldBeDispatchedWithCorrectUserId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (QueueWindowsNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueWindowsNotificationCommand));
            command.UserId.Should().Be(_event.UserId);
        }

        [Then]
        public void QueueWindowsNotificationCommandShouldBeDispatchedWithCorrectPayload()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var eventSerializer = _serviceProvider.GetRequiredService<IEventSerializer>();
            var command = (QueueWindowsNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueWindowsNotificationCommand));
            command.Payload.Should().Be(eventSerializer.Serialize(_event));
        }

        [Then]
        public void QueueWindowsNotificationCommandShouldBeDispatchedWithCorrectTemplate()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (QueueWindowsNotificationCommand)commandDispatcher.Commands.First(c => c.GetType() == typeof(QueueWindowsNotificationCommand));
            command.Template.Should().Be(nameof(TranslationSucceded));
        }
    }
}
