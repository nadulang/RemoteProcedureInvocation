using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Models;

namespace NotificationService.Application.UseCases.Notifications.Command.CreateAll
{
    public class CreateAllCommand : BaseRequest<AllNotificationsforInput>, IRequest<BaseDto<AllNotificationsforInput>>
    {
        
    }
}
