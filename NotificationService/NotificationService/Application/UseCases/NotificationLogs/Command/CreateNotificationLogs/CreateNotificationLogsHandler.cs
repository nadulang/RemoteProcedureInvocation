using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.NotificationLogs.Command.CreateNotificationLogs
{
    public class CreateNotificationLogsHandler : IRequestHandler<BaseRequest<NotificationLogs_>, BaseDto<NotificationLogs_>>
    {
        private readonly NotificationContext _context;

        public CreateNotificationLogsHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<NotificationLogs_>> Handle(BaseRequest<NotificationLogs_> request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;

            var not = new Domain.Entities.NotificationLogs_
            {
                notification_id = input.notification_id,
                type = input.type,
                from = input.from,
                target = input.target
            };

            _context.Logs.Add(not);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<NotificationLogs_>
            {
                message = "Success add a data",
                success = true,
                data = new NotificationLogs_
                {
                    id = not.id,
                    notification_id = input.notification_id,
                    type = input.type,
                    from = input.from,
                    target = input.target,
                    read_at = (long)time,
                    created_at = (long)time,
                    updated_at = (long)time
                }
            };
        }
    }
}
