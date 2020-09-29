using System;
using System.Collections.Generic;
using System.Text;

namespace SIO.Domain.Notifications.Projections
{
    public class NotificationFailure
    {
        public Guid Id { get; set; }
        public Guid NotificationId { get; set; }
        public string Error { get; set; }
    }
}
