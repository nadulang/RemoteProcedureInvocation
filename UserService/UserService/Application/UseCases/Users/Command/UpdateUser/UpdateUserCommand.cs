using UserService.Application.Models.Query;
using UserService.Domain.Entities;

namespace UserService.Application.UseCases.Users.Command.UpdateUser
{
    public class UpdateUserCommand : BaseRequest<Users_>
    {
        public int Id { get; set; }

        public UpdateUserCommand(int id)
        {
            Id = id;
        }
    }
}
