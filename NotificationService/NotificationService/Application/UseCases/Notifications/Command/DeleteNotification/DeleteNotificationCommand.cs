using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.UseCases.Notifications.Command.DeleteNotification
{
    public class DeleteNotificationCommand : IRequest<BaseDto<Notifications_>>
    {
        public int Id { get; set; }

        public DeleteNotificationCommand(int id)
        {
            Id = id;
        }
    }
}
