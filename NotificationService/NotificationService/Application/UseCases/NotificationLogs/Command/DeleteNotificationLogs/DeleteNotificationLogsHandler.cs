using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.NotificationLogs.Command.DeleteNotificationLogs
{
    public class DeleteNotificationLogsHandler : IRequestHandler<DeleteNotificationLogsCommand, BaseDto<NotificationLogs_>>
    {
        private readonly NotificationContext _context;

        public DeleteNotificationLogsHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<NotificationLogs_>> Handle(DeleteNotificationLogsCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.Logs.FindAsync(request.Id);

            if (delete == null)
            {
                return null;
            }

            else
            {
                _context.Logs.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<NotificationLogs_>
                {
                    success = true,
                    message = "Successfully deleted a log"
                };

            }
        }
    }
}
