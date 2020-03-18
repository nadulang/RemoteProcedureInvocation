using System.Collections.Generic;

namespace NotificationService.Application.UseCases.Notifications.Models
{
    public class AllNotifications
    {
        public List<Notifications2> notification { get; set; }
        public List<NotificationLogs2> logs { get; set; }
    }

    public class Notifications2
    {
        public int id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
    }

    public class NotificationLogs2
    {
        public int notification_id { get; set; }
        public string type { get; set; }
        public int from { get; set; }
        public int target { get; set; }
        public long read_at { get; set; }
    }
}
