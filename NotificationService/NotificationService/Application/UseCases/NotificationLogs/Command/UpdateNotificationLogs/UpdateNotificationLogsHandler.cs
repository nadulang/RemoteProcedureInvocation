using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.NotificationLogs.Command.UpdateNotificationLogs
{
    public class UpdateNotificationLogsHandler : IRequestHandler<UpdateNotificationLogsCommand, BaseDto<NotificationLogs_>>
    {
        private readonly NotificationContext _context;

        public UpdateNotificationLogsHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<NotificationLogs_>> Handle(UpdateNotificationLogsCommand request, CancellationToken cancellationToken)
        {

            var user = _context.Logs.Find(request.Id);
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;

            user.notification_id = request.data.attributes.notification_id;
            user.type = request.data.attributes.type;
            user.from = request.data.attributes.from;
            user.target = request.data.attributes.target;

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<NotificationLogs_>
            {
                success = true,
                message = "Data is successfully updated",
                data = new NotificationLogs_
                {
                    id = user.id,
                    notification_id = request.data.attributes.notification_id,
                    type = request.data.attributes.type,
                    from = request.data.attributes.from,
                    target = request.data.attributes.target,
                    read_at = (long)time,
                    created_at = (long)time,
                    updated_at = (long)time

                }
            };

        }
    }
}
