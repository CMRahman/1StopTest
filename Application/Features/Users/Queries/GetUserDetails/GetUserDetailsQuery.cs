using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsDto>
    {
        public Guid UserId { get; set; }
    }

    public record UserDetailsDto(Guid UserId, string UserName, string FirstName, string LastName, UserAddressDto Address);

    public record UserAddressDto(string State, int PostCode);
}
