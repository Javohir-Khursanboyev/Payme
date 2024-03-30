using Payme.Service.DTOs.Users;

namespace Payme.Service.Interface;

public interface IUserService
{
    Task<UserViewModel> CreateAsync(UserCreationModel user);
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user, bool IsUsesDeleted);
    Task<UserViewModel> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<UserViewModel>> GetAllAsync();
}
