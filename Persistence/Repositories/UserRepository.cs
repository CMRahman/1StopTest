using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OneStopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<User>> GetUsersWithAccounts()
        {
            var allUsers = await _dbContext.Users.Include(x => x.Accounts).ToListAsync();
            return allUsers;
        }
    }
}
