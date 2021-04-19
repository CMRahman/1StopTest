using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Users.Queries.GetUserAccounts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OneStopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserWithAddress(Guid userId)
        {
            return await DbContext.Users.Include(e => e.Address).FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
