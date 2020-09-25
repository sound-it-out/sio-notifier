using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SIO.Infrastructure.Notifications;
using SIO.Migrations.Entities;

namespace SIO.Infrastructure.Azure.Tests.Stubs
{
    internal sealed class FakeNotificationMessageBuilder : INotificationMessageBuilder
    {
        public Task<string> BuildAsync(Notification notification)
        {
            return Task.FromResult("test message");
        }
    }
}
