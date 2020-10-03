using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SIO.Infrastructure.Notifications.Processors;

namespace SIO.Testing.Fakes.Notifications.Builders
{
    public sealed class FakeIosNotificationProcessor : IIosNotificationProcessor
    {
        private readonly bool _throwException;
        private readonly string _exceptionMessage;

        public FakeIosNotificationProcessor(bool throwException, string exceptionMessage)
        {
            _throwException = throwException;
            _exceptionMessage = exceptionMessage;
        }

        public Task ProcessAsync(string message, IEnumerable<string> tags)
        {
            if (_throwException)
                throw new Exception(_exceptionMessage);

            return Task.CompletedTask;
        }
    }
}
