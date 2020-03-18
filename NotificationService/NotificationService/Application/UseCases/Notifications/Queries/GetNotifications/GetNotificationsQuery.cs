using System.Collections.Generic;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.UseCases.Notifications.Queries.GetNotifications
{
    public class GetNotificationsQuery : IRequest<BaseDto<List<Notifications_>>>
    {
        
    }
}
