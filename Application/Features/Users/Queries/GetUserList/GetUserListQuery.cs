using System;
using System.Collections.Generic;
using MediatR;

namespace Application.Features.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<List<UserListDto>>
    {
        
    }

    public record UserListDto(Guid UserId, string UserName, string FirstName, string LastName);
}
