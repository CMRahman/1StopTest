using System;
using Application.Features.Users.Queries.GetUserAccounts;
using MediatR;

namespace Application.Features.Account.Query.GetAccount
{
    public class GetAccountDetailsQuery : IRequest<AccountDto>
    {
        public Guid AccountId { get; set; }
    }
}
