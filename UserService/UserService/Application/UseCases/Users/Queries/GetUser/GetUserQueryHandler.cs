using MediatR;
using System.Threading.Tasks;
using System.Threading;
using UserService.Domain.Entities;
using UserService.Application.Models.Query;
using UserService.Infrastructure.Persistences;

namespace UserService.Application.UseCases.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, BaseDto<Users_>>
    {
        private readonly UsersContext _context;

        public GetUserQueryHandler(UsersContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<Users_>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.UsersData.FindAsync(request.Id);
            if (result == null)
            {
                return null;
            }
            else
            {
                return new BaseDto<Users_>
                {
                    success = true,
                    message = "User succesfully retrieved",
                    data = result
                };
            }
        }
    }
}
