using Application.Contracts.Persistence;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(OneStopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
