using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.UseCases.NotificationLogs.Queries.GetNotificationLog
{
    public class GetNotificationLogQuery : IRequest<BaseDto<NotificationLogs_>>
    {
        public int Id { get; set; }

        public GetNotificationLogQuery(int id)
        {
            Id = id;
        }
    }
}

