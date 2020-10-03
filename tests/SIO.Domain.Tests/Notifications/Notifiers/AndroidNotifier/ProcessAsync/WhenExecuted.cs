using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using OpenEventSourcing.Commands;
using OpenEventSourcing.Extensions;
using SIO.Domain.Notifications.Commands;
using SIO.Testing.Attributes;

namespace SIO.Domain.Tests.Notifications.Notifiers.AndroidNotifier.ProcessAsync
{
    public class WhenExecuted : AndroidNotifierSpecification
    {
        private readonly Guid _notificationId = Guid.NewGuid().ToSequentialGuid();
        private readonly int _version = 1;
        protected override Task Given()
        {
            return AndroidNotifier.ProcessAsync(_notificationId, _version);
        }

        protected override Task When()
        {
            return Task.CompletedTask;
        }

        [Then]
        void ProcessAndroidNotificationCommandShouldBeDispatched()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            commandDispatcher.Commands.First().Should().BeOfType<ProcessAndroidNotificationCommand>();
        }

        [Then]
        void ProcessAndroidNotificationCommandShouldBeDispatchedWithCorrectAggregateId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (ProcessAndroidNotificationCommand)commandDispatcher.Commands.First();
            command.AggregateId.Should().Be(_notificationId);
        }

        [Then]
        void ProcessAndroidNotificationCommandShouldBeDispatchedWithCorrectUserId()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (ProcessAndroidNotificationCommand)commandDispatcher.Commands.First();
            command.UserId.Should().Be(Guid.Empty.ToString());
        }

        [Then]
        void ProcessAndroidNotificationCommandShouldBeDispatchedWithCorrectVersion()
        {
            var commandDispatcher = (FakeCommandDispatcher)_serviceProvider.GetRequiredService<ICommandDispatcher>();
            var command = (ProcessAndroidNotificationCommand)commandDispatcher.Commands.First();
            command.Version.Should().Be(_version);
        }
    }
}
