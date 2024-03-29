using Payme.Domain.Entities.Users;

namespace Payme.Data.IRepositories;

public interface IUserRepository
{
    Task<User> InsertAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> SelectAsync(long id);
    Task<bool> DeleteAsync (User user);
    Task<IEnumerable<User>> SelectAllAsIEnumurable();
    Task<IQueryable<User>> SelectAllIQueryable();
    Task SaveAsync();
}