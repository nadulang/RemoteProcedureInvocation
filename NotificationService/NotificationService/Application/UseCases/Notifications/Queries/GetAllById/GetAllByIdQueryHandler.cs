using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Models;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Queries.GetAllById
{
    public class GetAllByIdQueryHandler : IRequestHandler<GetAllByIdQuery, BaseDto<AllNotifications>>
    {
        private readonly NotificationContext _context;

        public GetAllByIdQueryHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<AllNotifications>> Handle(GetAllByIdQuery request, CancellationToken cancellationToken)
        {
            var findnotId = _context.Notifications.Where(e => e.id == request.id);
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;

            if (findnotId == null)
            {
                return new BaseDto<AllNotifications>
                {
                    message = "Not Found",
                    success = false
                };
            }

            else
            {
                return new BaseDto<AllNotifications>
                {
                    message = "success retrieve notification data",
                    success = true,
                    data = new AllNotifications
                    {
                        notification = await findnotId.Select(s => new Notifications2
                        {
                            id = s.id,
                            title = s.title,
                            message = s.message
                        }).ToListAsync(),

                        logs = (request.include.ToLower() == "logs") ?
                                            await _context.Logs.Where(x => x.notification_id == request.id)
                                            .Select(s => new NotificationLogs2
                                            {
                                                notification_id = s.notification_id,
                                                from = s.from,
                                                read_at = s.read_at,
                                                target = s.target
                                            }).ToListAsync() :
                                            null



                    }

                };

            }

        }

    }
}


