using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Command.CreateNotification
{
    public class CreateNotificationHandler : IRequestHandler<BaseRequest<Notifications_>, BaseDto<Notifications_>>
    {
        private readonly NotificationContext _context;

        public CreateNotificationHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Notifications_>> Handle(BaseRequest<Notifications_> request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;

            var not = new Domain.Entities.Notifications_
            {
                title = input.title,
                message = input.message
            };

            _context.Notifications.Add(not);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<Notifications_>
            {
                message = "Success add a data",
                success = true,
                data = new Notifications_
                {
                    id = not.id,
                    title = input.title,
                    message = input.message,
                    created_at = (long)time,
                    updated_at = (long)time
                }
            };
        }
    }
}
