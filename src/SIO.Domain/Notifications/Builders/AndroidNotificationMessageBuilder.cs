using OpenEventSourcing.Events;
using OpenEventSourcing.Serialization;

namespace SIO.Domain.Notifications.Builders
{
    internal sealed class AndroidNotificationMessageBuilder : NotificationMessageBuilder, IAndroidNotificationMessageBuilder
    {
        public AndroidNotificationMessageBuilder(IRazorViewBuilder razorViewBuilder, IEventDeserializer eventDeserializer, IEventTypeCache eventTypeCache) : base(razorViewBuilder, eventDeserializer, eventTypeCache)
        {
        }

        public override string FormatMessage(string message) => $@"{{ ""data"" : {{ ""message"": ""{message}"" }}}}";
    }
}
