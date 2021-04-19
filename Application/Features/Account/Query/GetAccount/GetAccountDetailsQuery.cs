using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Users.Queries.GetUserAccounts;
using MediatR;

namespace Application.Features.Account.Query.GetAccount
{
    public class GetAccountDetailsQuery : IRequest<AccountDto>
    {
        public Guid AccountId { get; set; }
    }
}
