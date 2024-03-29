using Payme.Data.IRepositories;
using Payme.Domain.Entities.Users;

namespace Payme.Data.Repositories;

public class UserRepository : IUserRepository
{
    public Task<bool> DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> InsertAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> SelectAllAsIEnumurable()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<User>> SelectAllIQueryable()
    {
        throw new NotImplementedException();
    }

    public Task<User> SelectAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
