using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Application.Models.Query;
using NotificationService.Application.UseCases.NotificationLogs.Queries.GetNotificationLogs;
using NotificationService.Application.UseCases.Notifications.Command.CreateAll;
using NotificationService.Application.UseCases.Notifications.Command.DeleteAll;
using NotificationService.Application.UseCases.Notifications.Command.UpdateNotificationsMultipleTargets;
using NotificationService.Application.UseCases.Notifications.Queries.GetAll;
using NotificationService.Application.UseCases.Notifications.Queries.GetAllById;
using NotificationService.Domain.Entities;

namespace NotificationService.Presenter.Controller
{
    [ApiController]
    [Route("api/notification")]

    public class NotificationController : ControllerBase
    {
        private IMediator _mediatr;

        public NotificationController(IMediator mediatr)
        {
            _mediatr = mediatr;

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(string include)
        {
            var Include = include ?? "Not Found";
            return Ok(await _mediatr.Send(new GetAllQuery() { include = Include }));
        }


        [HttpGet("logs")]
        public async Task<IActionResult> GetLogs()
        {
            return Ok(await _mediatr.Send(new GetNotificationLogsQuery()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto<Notifications_>>> Get(int id, string include)
        {

            var Include = include ?? "None";
            return Ok(await _mediatr.Send(new GetAllByIdQuery() { id = id, include = Include }));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAllCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAllCommand(id);
            var result = await _mediatr.Send(command);

            return command != null ? (IActionResult)Ok(new { Message = "deleted" }) : NotFound(new { Message = "not found" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] UpdateNotificationsMultipleTargetsCommand req)
        {

            return Ok(await _mediatr.Send(new UpdateNotificationsMultipleTargetsCommand()
            {
                id = Id,
                data = req.data
            }));

        }

    }
}
