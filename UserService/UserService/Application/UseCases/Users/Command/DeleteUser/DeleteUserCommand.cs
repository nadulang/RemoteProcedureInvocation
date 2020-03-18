using MediatR;
using UserService.Application.Models.Query;
using UserService.Domain.Entities;

namespace UserService.Application.UseCases.Users.Command.DeleteUser
{
    public class DeleteUserCommand : IRequest<BaseDto<Users_>>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
