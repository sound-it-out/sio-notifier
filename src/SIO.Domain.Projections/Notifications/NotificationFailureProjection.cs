using System;
using System.Threading.Tasks;
using OpenEventSourcing.Extensions;
using OpenEventSourcing.Projections;
using SIO.Domain.Notifications.Events;
using SIO.Domain.Notifications.Projections;

namespace SIO.Domain.Projections.Notifications
{
    public sealed class NotificationFailureProjection : Projection<NotificationFailure>
    {
        public NotificationFailureProjection(IProjectionWriter<NotificationFailure> writer) : base(writer)
        {
            Handles<NotificationFailed>(HandleAsync);
        }

        public async Task HandleAsync(NotificationFailed @event)
        {
            var id = Guid.NewGuid().ToSequentialGuid();
            await _writer.Add(id, () =>
            {
                return new NotificationFailure
                {
                    Id = id,
                    NotificationId = @event.AggregateId,
                    Error = @event.Error
                };
            });
        }
    }
}
