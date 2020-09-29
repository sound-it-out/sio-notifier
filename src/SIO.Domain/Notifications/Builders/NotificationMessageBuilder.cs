using System;
using System.Threading.Tasks;
using OpenEventSourcing.Events;
using OpenEventSourcing.Serialization;
using SIO.Domain.Notifications.Aggregates;

namespace SIO.Domain.Notifications.Builders
{
    internal abstract class NotificationMessageBuilder
    {
        private readonly IRazorViewBuilder _razorViewBuilder;
        private readonly IEventDeserializer _eventDeserializer;
        private readonly IEventTypeCache _eventTypeCache;

        public NotificationMessageBuilder(IRazorViewBuilder razorViewBuilder,
            IEventDeserializer eventDeserializer,
            IEventTypeCache eventTypeCache)
        {
            if (razorViewBuilder == null)
                throw new ArgumentNullException(nameof(razorViewBuilder));
            if (eventDeserializer == null)
                throw new ArgumentNullException(nameof(eventDeserializer));
            if (eventTypeCache == null)
                throw new ArgumentNullException(nameof(eventTypeCache));

            _razorViewBuilder = razorViewBuilder;
            _eventDeserializer = eventDeserializer;
            _eventTypeCache = eventTypeCache;
        }
        public abstract string FormatMessage(string message);

        public async Task<string> BuildAsync(NotificationState notification)
        {
            if (!_eventTypeCache.TryGet(notification.Template, out var type))
                throw new InvalidOperationException();

            var message = await _razorViewBuilder.BuildAsync(notification.Template, _eventDeserializer.Deserialize(notification.Payload, type));
            return FormatMessage(message);
        }
    }
}
