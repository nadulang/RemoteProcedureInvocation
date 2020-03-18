using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserService.Application.Models.Query;
using UserService.Domain.Entities;
using UserService.Infrastructure.Persistences;

namespace UserService.Application.UseCases.Users.Command.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, BaseDto<Users_>>
    {
        private readonly UsersContext _context;

        public UpdateUserHandler(UsersContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Users_>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var user = _context.UsersData.Find(request.Id);

           
                user.name = request.data.attributes.name;
                user.username = request.data.attributes.username;
                user.email = request.data.attributes.email;
                user.password = request.data.attributes.password;
                user.address = request.data.attributes.address;

                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<Users_>
                {
                    success = true,
                    message = "Data is successfully updated"
                };
            
        }
    }
}
