using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(OneStopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Account>> GetUserAccounts(Guid userId)
        {
            var userAccounts = await DbContext.Accounts.Where(x => x.UserId == userId).ToListAsync();
            return userAccounts;
        }
    }
}
