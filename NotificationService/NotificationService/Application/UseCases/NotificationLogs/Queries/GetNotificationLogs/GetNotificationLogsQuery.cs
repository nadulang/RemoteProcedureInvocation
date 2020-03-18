using System;
using System.Collections.Generic;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.UseCases.NotificationLogs.Queries.GetNotificationLogs
{
    public class GetNotificationLogsQuery : IRequest<BaseDto<List<NotificationLogs_>>>
    {
        
    }
}
