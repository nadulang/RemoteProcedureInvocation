using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Command.UpdateNotification
{
    public class UpdateNotificationHandler : IRequestHandler<UpdateNotificationCommand, BaseDto<Notifications_>>
    {
        private readonly NotificationContext _context;

        public UpdateNotificationHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Notifications_>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var not = _context.Notifications.Find(request.id);
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
            not.title = request.data.attributes.title;
            not.message = request.data.attributes.message;
            not.updated_at = (long)time;

            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<Notifications_>
            {
                success = true,
                message = "notification successfully updated"
            };
        }
    }
}
