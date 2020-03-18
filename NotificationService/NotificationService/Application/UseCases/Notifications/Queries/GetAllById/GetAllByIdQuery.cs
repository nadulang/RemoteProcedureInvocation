using System;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Models;

namespace NotificationService.Application.UseCases.Notifications.Queries.GetAllById
{
    public class GetAllByIdQuery : IRequest<BaseDto<AllNotifications>>
    {
        public int id { get; set; }
        public string include { get; set; }

    }
}
