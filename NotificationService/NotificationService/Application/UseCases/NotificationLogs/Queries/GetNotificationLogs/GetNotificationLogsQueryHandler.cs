using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.NotificationLogs.Queries.GetNotificationLogs
{
    public class GetNotificationLogsQueryHandler : IRequestHandler<GetNotificationLogsQuery, BaseDto<List<NotificationLogs_>>>
    {
        private readonly NotificationContext _context;

        public GetNotificationLogsQueryHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<List<NotificationLogs_>>> Handle(GetNotificationLogsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Logs.ToListAsync();
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;

            var result = data.Select(e => new NotificationLogs_
            {
                id = e.id,
                notification_id = e.notification_id,
                type = e.type,
                target = e.target,
                read_at = (long)time,
                created_at = (long)time,
                updated_at = (long)time
            }); ;

            return new BaseDto<List<NotificationLogs_>>
            {
                message = "Success retrieving data",
                success = true,
                data = result.ToList()
            };
        }
    }
}
