using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Models;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, BaseDto<AllNotifications>>
    {
        private readonly NotificationContext _context;

        public GetAllQueryHandler(NotificationContext context)
        {
            _context = context;
        }
        public async Task<BaseDto<AllNotifications>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var not = await _context.Notifications.ToListAsync();
            var log = await _context.Logs.ToListAsync();
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;

            var resultnotif = not.Select(b => new Notifications2
            {
                id = b.id,
                title = b.title,
                message = b.message

            });

            var resultlog = log.Select(p => new NotificationLogs2
            {
                notification_id = p.notification_id,
                type = p.type,
                target = p.target,
                read_at = (long)time
            });

            return new BaseDto<AllNotifications>
            {

                message = "Success retrieving data",
                success = true,
                data = new AllNotifications
                {
                    notification = resultnotif.ToList(),
                    logs = resultlog.ToList()
                }
                

            };
        }

    }

}
