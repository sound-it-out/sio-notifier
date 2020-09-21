using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SIO.Migrations.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid? CausationId { get; set; }
        public NotificationStatus AndroidStatus { get; set; }
        public NotificationStatus IosStatus { get; set; }
        public NotificationStatus WindowsStatus { get; set; }
        public int AndroidAttempts { get; set; }
        public int IosAttempts { get; set; }
        public int WindowsAttempts { get; set; }
        public string Template { get; set; }
        public string Payload { get; set; }
        public string TagsValue { get; set; }
        public IEnumerable<string> Tags 
        {
            get
            {
                return JsonConvert.DeserializeObject<IEnumerable<string>>(TagsValue);
            }
            set
            {
                TagsValue = JsonConvert.SerializeObject(value);
            } 
        }
    }
}
