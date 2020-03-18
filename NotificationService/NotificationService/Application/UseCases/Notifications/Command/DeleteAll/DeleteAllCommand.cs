using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Models;

namespace NotificationService.Application.UseCases.Notifications.Command.DeleteAll
{
    public class DeleteAllCommand : IRequest<BaseDto<AllNotifications>>
    {
        public int Id { get; set; }

        public DeleteAllCommand(int id)
        {
            Id = id;
        }
    }
}