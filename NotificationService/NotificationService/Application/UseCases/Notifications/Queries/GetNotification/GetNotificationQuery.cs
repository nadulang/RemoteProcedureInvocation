using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.UseCases.Notifications.Queries.GetNotification
{
    public class GetNotificationQuery : IRequest<BaseDto<Notifications_>>
    {
        public int Id { get; set; }

        public GetNotificationQuery(int id)
        {
            Id = id;
        }
    }
}
