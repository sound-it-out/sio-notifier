namespace SIO.Infrastructure.Azure.Notifications
{
    public sealed class AzureNotificationOptions
    {
        public string ConnectionString { get; set; }
        public string HubPath { get; set; }
    }
}
