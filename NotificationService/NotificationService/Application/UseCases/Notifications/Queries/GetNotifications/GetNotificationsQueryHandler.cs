using System.Linq;
using System.Collections.Generic;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;
using Microsoft.EntityFrameworkCore;

namespace NotificationService.Application.UseCases.Notifications.Queries.GetNotifications
{
    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, BaseDto<List<Notifications_>>>
    {
        private readonly NotificationContext _context;

        public GetNotificationsQueryHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<List<Notifications_>>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Notifications.ToListAsync();

            var result = data.Select(e => new Notifications_
            {
                id = e.id,
                title = e.title,
                message = e.message,
                created_at = e.created_at,
                updated_at = e.updated_at
            });

            return new BaseDto<List<Notifications_>>
            {
                message = "Success retrieving data",
                success = true,
                data = result.ToList()
            };
        }
    }
}
