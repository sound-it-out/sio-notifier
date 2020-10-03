using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using OpenEventSourcing.Commands;
using OpenEventSourcing.Extensions;
using SIO.Domain.Notifications.Commands;
using SIO.Testing.Attributes;

namespace SIO.Domain.Tests.Notifications.Notifiers.IosNotifier.ProcessAsync
{
    public class WhenExecuted : IosNotifierSpecification
    {
        private readonly Guid _notificationId = Guid.NewGuid().ToSequentialGuid();
        private readonly int _version = 1;
        protected override Task Given()
        {
            return IosNotifier.ProcessAsync(_notificationId, _version);
        }

        protected override Task When()
        {
            return Task.CompletedTask;
        }

        [Then]
        void ProcessIosNotificationCommandShouldBeDispatched()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            commandDispatcher.Commands.First().Should().BeOfType<ProcessIosNotificationCommand>();
        }

        [Then]
        void ProcessIosNotificationCommandShouldBeDispatchedWithCorrectAggregateId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (ProcessIosNotificationCommand)commandDispatcher.Commands.First();
            command.AggregateId.Should().Be(_notificationId);
        }

        [Then]
        void ProcessIosNotificationCommandShouldBeDispatchedWithCorrectUserId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (ProcessIosNotificationCommand)commandDispatcher.Commands.First();
            command.UserId.Should().Be(Guid.Empty.ToString());
        }

        [Then]
        void ProcessIosNotificationCommandShouldBeDispatchedWithCorrectVersion()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (ProcessIosNotificationCommand)commandDispatcher.Commands.First();
            command.Version.Should().Be(_version);
        }
    }
}
