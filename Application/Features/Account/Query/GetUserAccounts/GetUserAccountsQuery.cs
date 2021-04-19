using System;
using System.Collections.Generic;
using MediatR;

namespace Application.Features.Users.Queries.GetUserAccounts
{
    public class GetUserAccountsQuery : IRequest<List<AccountDto>>
    {
        public Guid UserId { get; set; }
    }

    public record AccountDto(Guid AccountId, string AccountName, Decimal Balance, Guid UserId);



}
