using System;
using MediatR;
using UserService.Application.Models.Query;
using UserService.Domain.Entities;

namespace UserService.Application.UseCases.Users.Queries.GetUser
{
    public class GetUserQuery : IRequest<BaseDto<Users_>>
    {
        public int Id { get; set; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}
