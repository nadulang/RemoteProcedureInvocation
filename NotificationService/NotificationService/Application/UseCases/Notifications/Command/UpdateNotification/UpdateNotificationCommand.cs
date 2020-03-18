using System;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.UseCases.Notifications.Command.UpdateNotification
{
    public class UpdateNotificationCommand : BaseRequest<Notifications_>
    {
        public int id { get; set; }
    }
}
