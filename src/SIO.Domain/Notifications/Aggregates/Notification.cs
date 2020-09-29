using System;
using System.Collections.Generic;
using OpenEventSourcing.Domain;
using SIO.Domain.Notifications.Events;

namespace SIO.Domain.Notifications.Aggregates
{
    public class Notification : Aggregate<NotificationState>
    {
        public Notification(NotificationState state) : base(state)
        {
            Handles<AndroidNotificationQueued>(Handle);
            Handles<IosNotificationQueued>(Handle);
            Handles<WindowsNotificationQueued>(Handle);
            Handles<NotificationFailed>(Handle);
            Handles<NotificationSucceded>(Handle);
        }

        public override NotificationState GetState() => new NotificationState(_state);

        public void QueueForAndroid(Guid aggregateId, string payload, string template, IEnumerable<string> tags) => Apply(new AndroidNotificationQueued(aggregateId, Version.GetValueOrDefault(), template, payload, tags));
        public void QueueForIos(Guid aggregateId, string payload, string template, IEnumerable<string> tags) => Apply(new IosNotificationQueued(aggregateId, Version.GetValueOrDefault(), template, payload, tags));
        public void QueueForWindows(Guid aggregateId, string payload, string template, IEnumerable<string> tags) => Apply(new WindowsNotificationQueued(aggregateId, Version.GetValueOrDefault(), template, payload, tags));
        public void MarkAsFail(string error) => Apply(new NotificationFailed(Id.Value, Version.GetValueOrDefault() + 1, error));
        public void MarkAsSuccess() => Apply(new NotificationSucceded(Id.Value, Version.GetValueOrDefault() + 1));

        public void Handle(AndroidNotificationQueued @event)
        {
            //if(Id.HasValue)
            // throw exception

            Id = @event.Id;
            _state.Attempts = 0;
            _state.Payload = @event.Payload;
            _state.Template = @event.Template;
            _state.Status = NotificationStatus.Pending;
            _state.Tags = @event.Tags;
            _state.Type = NotificationType.Android;
            Version = @event.Version;
        }

        public void Handle(IosNotificationQueued @event)
        {
            //if(Id.HasValue)
            // throw exception

            Id = @event.Id;
            _state.Attempts = 0;
            _state.Payload = @event.Payload;
            _state.Status = NotificationStatus.Pending;
            _state.Tags = @event.Tags;
            _state.Type = NotificationType.Ios;
            Version = @event.Version;
        }

        public void Handle(WindowsNotificationQueued @event)
        {
            //if(Id.HasValue)
            // throw exception

            Id = @event.Id;
            _state.Attempts = 0;
            _state.Payload = @event.Payload;
            _state.Status = NotificationStatus.Pending;
            _state.Tags = @event.Tags;
            _state.Type = NotificationType.Windows;
            Version = @event.Version;
        }

        public void Handle(NotificationFailed @event)
        {
            _state.Attempts++;
            _state.Status = NotificationStatus.Failed;
            Version = @event.Version;
        }

        public void Handle(NotificationSucceded @event)
        {
            _state.Attempts++;
            _state.Status = NotificationStatus.Success;
            Version = @event.Version;
        }
    }
}
