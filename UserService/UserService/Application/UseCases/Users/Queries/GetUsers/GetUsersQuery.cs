using System.Collections.Generic;
using MediatR;
using UserService.Application.Models.Query;
using UserService.Domain.Entities;

namespace UserService.Application.UseCases.Users.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<BaseDto<List<Users_>>>
    {
        
    }
}
