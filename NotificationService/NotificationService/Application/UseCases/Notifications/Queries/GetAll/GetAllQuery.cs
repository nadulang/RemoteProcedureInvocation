using System.Collections.Generic;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Models;

namespace NotificationService.Application.UseCases.Notifications.Queries.GetAll
{
    public class GetAllQuery : IRequest<BaseDto<AllNotifications>>
    {
        public string include { get; set; }
        public string email { get; set; }
    }

}
