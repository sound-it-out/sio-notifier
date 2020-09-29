using OpenEventSourcing.Events;
using OpenEventSourcing.Serialization;

namespace SIO.Domain.Notifications.Builders
{
    internal sealed class IosNotificationMessageBuilder : NotificationMessageBuilder, IIosNotificationMessageBuilder
    {
        public IosNotificationMessageBuilder(IRazorViewBuilder razorViewBuilder, IEventDeserializer eventDeserializer, IEventTypeCache eventTypeCache) : base(razorViewBuilder, eventDeserializer, eventTypeCache)
        {
        }

        public override string FormatMessage(string message) => $@"{{ ""aps"" : {{ ""alert"": ""{message}"" }}}}";
    }
}
