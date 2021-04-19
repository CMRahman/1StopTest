using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IAccountRepository : IAsyncRepository<Account>
    {
       Task<List<Account>> GetUserAccounts(Guid userId);

    }
}
