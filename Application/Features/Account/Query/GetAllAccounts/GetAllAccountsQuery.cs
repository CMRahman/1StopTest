using System.Collections.Generic;
using Application.Features.Users.Queries.GetUserAccounts;
using MediatR;

namespace Application.Features.Account.Query.GetAllAccounts
{
    public class GetAllAccountsQuery : IRequest<List<AccountDto>>
    {
    }
}