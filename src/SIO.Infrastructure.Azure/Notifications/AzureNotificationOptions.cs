using System;
using System.Collections.Generic;
using System.Text;

namespace SIO.Infrastructure.Azure.Notifications
{
    internal sealed class AzureNotificationOptions
    {
        public string ConnectionString { get; set; }
        public string HubPath { get; set; }
    }
}
