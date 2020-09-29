using OpenEventSourcing.Events;
using OpenEventSourcing.Serialization;

namespace SIO.Domain.Notifications.Builders
{
    internal sealed class WindowsNotificationMessageBuilder : NotificationMessageBuilder, IWindowsNotificationMessageBuilder
    {
        public WindowsNotificationMessageBuilder(IRazorViewBuilder razorViewBuilder, IEventDeserializer eventDeserializer, IEventTypeCache eventTypeCache) : base(razorViewBuilder, eventDeserializer, eventTypeCache)
        {
        }

        public override string FormatMessage(string message) => $@"<toast><visual><binding template=""ToastText01""><text id=""1"">{message}</text></binding></visual></toast>";
    }
}
