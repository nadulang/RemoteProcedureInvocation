using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Models;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Command.DeleteAll
{
    public class DeleteAllCommandHandler : IRequestHandler<DeleteAllCommand, BaseDto<AllNotifications>>
    {
        private readonly NotificationContext _context;

        public DeleteAllCommandHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<AllNotifications>> Handle(DeleteAllCommand request, CancellationToken cancellationToken)
        {
            var deletenotif = await _context.Notifications.FindAsync(request.Id);
            var deletelog = _context.Logs.Where(e => e.notification_id == request.Id);

            if (deletenotif == null && deletelog == null)
            {
                return new BaseDto<AllNotifications>
                {
                    message = "Not Found",
                    success = false
                };
            }

            else
            {
                _context.Notifications.Remove(deletenotif);
                await _context.SaveChangesAsync(cancellationToken);


                _context.Logs.RemoveRange(deletelog);
                await _context.SaveChangesAsync();

                return new BaseDto<AllNotifications>
                {
                    message = "notification has been deleted",
                    success = true
                };
            }

        }
    }
}