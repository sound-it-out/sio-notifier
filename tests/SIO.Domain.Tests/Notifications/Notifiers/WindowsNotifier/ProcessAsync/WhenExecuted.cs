using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using OpenEventSourcing.Commands;
using OpenEventSourcing.Extensions;
using SIO.Domain.Notifications.Commands;
using SIO.Testing.Attributes;

namespace SIO.Domain.Tests.Notifications.Notifiers.WindowsNotifier.ProcessAsync
{
    public class WhenExecuted : WindowsNotifierSpecification
    {
        private readonly Guid _notificationId = Guid.NewGuid().ToSequentialGuid();
        private readonly int _version = 1;
        protected override Task Given()
        {
            return WindowsNotifier.ProcessAsync(_notificationId, _version);
        }

        protected override Task When()
        {
            return Task.CompletedTask;
        }

        [Then]
        void ProcessWindowsNotificationCommandShouldBeDispatched()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            commandDispatcher.Commands.First().Should().BeOfType<ProcessWindowsNotificationCommand>();
        }

        [Then]
        void ProcessWindowsNotificationCommandShouldBeDispatchedWithCorrectAggregateId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (ProcessWindowsNotificationCommand)commandDispatcher.Commands.First();
            command.AggregateId.Should().Be(_notificationId);
        }

        [Then]
        void ProcessWindowsNotificationCommandShouldBeDispatchedWithCorrectUserId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (ProcessWindowsNotificationCommand)commandDispatcher.Commands.First();
            command.UserId.Should().Be(Guid.Empty.ToString());
        }

        [Then]
        void ProcessWindowsNotificationCommandShouldBeDispatchedWithCorrectVersion()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (ProcessWindowsNotificationCommand)commandDispatcher.Commands.First();
            command.Version.Should().Be(_version);
        }
    }
}
