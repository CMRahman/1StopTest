using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserWithAddress(Guid userId);
    }
}
