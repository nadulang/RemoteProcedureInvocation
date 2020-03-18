using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.Notifications.Models;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Command.UpdateNotificationsMultipleTargets
{
    public class UpdateNotificationsMultipleTargetsCommandHandler : IRequestHandler<UpdateNotificationsMultipleTargetsCommand, BaseDto<AllNotificationsforUpdate>>
    {
        private readonly NotificationContext _context;

        public UpdateNotificationsMultipleTargetsCommandHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<AllNotificationsforUpdate>> Handle(UpdateNotificationsMultipleTargetsCommand request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var not = _context.Notifications.Find(request.id);
            var time = (DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;

            foreach (var nots in input.target)
            {
                var update = _context.Logs.First(x => x.notification_id == not.id && x.target == nots.id);
                update.read_at = (long)time;
                await _context.SaveChangesAsync();
            }

            return new BaseDto<AllNotificationsforUpdate>
            {
                message = "notification has been updated",
                success = true,
                data = input
            };
        }
    }
}
