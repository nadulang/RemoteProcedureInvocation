using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace NotificationService.Application.UseCases.Notifications.Models
{
    public class AllNotificationsforInput
    {
        public string title { get; set; }
        public string message { get; set; }
        public string type { get; set; }
        public int from { get; set; }
        public List<Targetss> target { get; set; }
    }


    public class Targetss
    {
        [Required]
        public int id { get; set; }
        [Required]
        [EmailAddress]
        public string email_destination { get; set; }
    }
}
