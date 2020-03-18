using NotificationService.Application.Models.Query;
using NotificationService.Domain.Entities;

namespace NotificationService.Application.UseCases.NotificationLogs.Command.UpdateNotificationLogs
{
    public class UpdateNotificationLogsCommand : BaseRequest<NotificationLogs_>
    {
        public int Id { get; set; }

        public UpdateNotificationLogsCommand(int id)
        {
            Id = id;
        }
    }
}
