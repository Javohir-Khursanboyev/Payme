using Payme.Service.DTOs.Users;

namespace Payme.Service.Services.UserServices;

public interface IUserService
{
    Task<UserViewModel> CreateAsync(UserCreationModel user);
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user, bool IsUsesDeleted = false);
    Task<UserViewModel> GetByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<UserViewModel>> GetAllAsync();
}
