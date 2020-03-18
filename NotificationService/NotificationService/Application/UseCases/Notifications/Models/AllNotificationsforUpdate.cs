using System;
using System.Collections.Generic;

namespace NotificationService.Application.UseCases.Notifications.Models
{
    public class AllNotificationsforUpdate 
    {
      public DateTime read_at { get; set; }
      public List<Targets> target { get; set; }
    }

    public class Targets
    {
        public int id { get; set; }
    }
}
