namespace SIO.Infrastructure.Azure.Notifications
{
    internal sealed class NotificationMessage
    {
        private readonly string _data;

        private NotificationMessage(string data)
        {
            _data = data;
        }

        public static implicit operator NotificationMessage(string data)
        {
            return new NotificationMessage(data);
        }

        public string ToAndroid() => $@"{{ ""data"" : {{ ""message"": ""{_data}"" }}}}";
        public string ToIos() => $@"{{ ""aps"" : {{ ""alert"": ""{_data}"" }}}}";
        public string ToWindows() => $@"<toast><visual><binding template=""ToastText01""><text id=""1"">{_data}</text></binding></visual></toast>";
    }
}
