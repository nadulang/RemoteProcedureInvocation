using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Models;
using NotificationService.Domain.Entities;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Command.CreateAll
{
    public class CreateAllCommandHandler : IRequestHandler<CreateAllCommand, BaseDto<AllNotificationsforInput>>
    {
        private readonly NotificationContext _context;

        public CreateAllCommandHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<AllNotificationsforInput>> Handle(CreateAllCommand request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;

            var notdata = new Notifications_
            {
                title = input.title,
                message = input.message
            };

            _context.Notifications.Add(notdata);
            await _context.SaveChangesAsync(cancellationToken);

            var ID = await _context.Notifications.ToListAsync();

            foreach (var log in input.target)
            {
                _context.Logs.Add(new NotificationLogs_
                {
                    notification_id = ID.Last().id,
                    type = input.type,
                    from = input.from,
                    target = log.id,
                    email_destination = log.email_destination
                });

                await _context.SaveChangesAsync();
            }

            return new BaseDto<AllNotificationsforInput>
            {
                message = "Notification data has been added successfully",
                success = true,
                data = input
            };
        }
    }
}
