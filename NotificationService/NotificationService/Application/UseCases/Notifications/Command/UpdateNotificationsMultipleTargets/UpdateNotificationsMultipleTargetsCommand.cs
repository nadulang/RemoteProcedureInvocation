using System;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Models;

namespace NotificationService.Application.UseCases.Notifications.Command.UpdateNotificationsMultipleTargets
{
    public class UpdateNotificationsMultipleTargetsCommand : BaseRequest<AllNotificationsforUpdate>, IRequest<BaseDto<AllNotificationsforUpdate>>
    {
        public int id { get; set; }

    }
}
