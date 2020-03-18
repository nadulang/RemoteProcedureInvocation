using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.NotificationLogs.Queries.GetNotificationLog
{
    public class GetNotificationLogQueryHandler : IRequestHandler<GetNotificationLogQuery, BaseDto<NotificationLogs_>>
    {
        private readonly NotificationContext _context;

        public GetNotificationLogQueryHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<NotificationLogs_>> Handle(GetNotificationLogQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Logs.FindAsync(request.Id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return new BaseDto<NotificationLogs_>
                {
                    success = true,
                    message = "Notification log succesfully retrieved",
                    data = result
                };
            }
        }
    }
}
