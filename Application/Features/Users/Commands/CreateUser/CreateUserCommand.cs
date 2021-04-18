using System;
using MediatR;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
