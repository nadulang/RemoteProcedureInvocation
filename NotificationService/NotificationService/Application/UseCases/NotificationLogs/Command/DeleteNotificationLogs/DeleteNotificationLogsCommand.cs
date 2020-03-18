using System;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.UseCases.NotificationLogs.Command.DeleteNotificationLogs
{
    public class DeleteNotificationLogsCommand : IRequest<BaseDto<NotificationLogs_>>
    {
        public int Id { get; set; }

        public DeleteNotificationLogsCommand(int id)
        {
            Id = id;
        }
    }
    
}
