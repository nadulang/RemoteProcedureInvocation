using MediatR;
using System.Threading.Tasks;
using System.Threading;
using NotificationService.Application.Models.Query;
using NotificationService.Infrastructure.Persistences;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.UseCases.Notifications.Queries.GetNotification
{
    public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, BaseDto<Notifications_>>
    {
        private readonly NotificationContext _context;

        public GetNotificationQueryHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Notifications_>> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Notifications.FindAsync(request.Id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return new BaseDto<Notifications_>
                {
                    success = true,
                    message = "Notification succesfully retrieved",
                    data = result
                };
            }
        }
    }
}
