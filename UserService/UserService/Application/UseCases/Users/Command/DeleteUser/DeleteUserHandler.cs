using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserService.Application.Models.Query;
using UserService.Domain.Entities;
using UserService.Infrastructure.Persistences;

namespace UserService.Application.UseCases.Users.Command.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, BaseDto<Users_>>
    {
        private readonly UsersContext _context;

        public DeleteUserHandler(UsersContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Users_>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.UsersData.FindAsync(request.Id);

            if (delete == null)
            {
                return null;
            }

            else
            {
                _context.UsersData.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<Users_>
                {
                    success = true,
                    message = "Successfully deleted a user"
                };

            }
        }
    }
}
