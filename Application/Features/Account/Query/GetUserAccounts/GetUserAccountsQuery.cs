using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Users.Queries.GetUserDetails;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetUserAccounts
{
    public class GetUserAccountsQuery : IRequest<List<AccountsDto>>
    {
        public Guid UserId { get; set; }
    }

    public record AccountsDto(Guid AccountId, string AccountName, Decimal Balance, Guid UserId);



}
