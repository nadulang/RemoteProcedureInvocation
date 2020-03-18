using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Command.DeleteNotification
{
    public class DeleteNotificationHandler : IRequestHandler<DeleteNotificationCommand, BaseDto<Notifications_>>
    {
        private readonly NotificationContext _context;

        public DeleteNotificationHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Notifications_>> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.Notifications.FindAsync(request.Id);

            if (delete == null)
            {
                return null;
            }

            else
            {
                _context.Notifications.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<Notifications_>
                {
                    success = true,
                    message = "Successfully deleted notification"
                };

            }
        }
    }
}
