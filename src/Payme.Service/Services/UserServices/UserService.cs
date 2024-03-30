using AutoMapper;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.Users;
using Payme.Service.DTOs.Users;
using Payme.Service.Exceptions;
using Payme.Service.Helpers;

namespace Payme.Service.Services.UserServices;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    public async Task<UserViewModel> CreateAsync(UserCreationModel user)
    {
        var users = await userRepository.SelectAllIQueryableAsync();
        var existUser = users.FirstOrDefault(u => u.Phone == user.Phone);
        if (existUser != null)
        {
            if (existUser.IsDeleted)
                return await UpdateAsync(existUser.Id, mapper.Map<UserUpdateModel>(user), true);

            throw new CustomException(409, "User is already exist");
        }

        user.Password = PasswordActions.Hashing(user.Password);
        var createdUser = await userRepository.InsertAsync(mapper.Map<User>(user));

        return mapper.Map<UserViewModel>(createdUser);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existUser = await userRepository.SelectAsync(id) ??
            throw new CustomException(404, "User is not found");

        existUser.DeletedAt = DateTime.UtcNow;
        await userRepository.DeleteAsync(existUser);
        return true;
    }

    public async Task<IEnumerable<UserViewModel>> GetAllAsync()
    {
        var users = await userRepository.SelectAllAsIEnumerableAsync();
        return mapper.Map<IEnumerable<UserViewModel>>(users);
    }

    public async Task<UserViewModel> GetByIdAsync(long id)
    {
        var existUser = await userRepository.SelectAsync(id) ??
            throw new CustomException(404, "User is not found");

        return mapper.Map<UserViewModel>(existUser);
    }

    public async Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user, bool IsUsesDeleted = false)
    {
        var existUser = new User();
        user.Password = PasswordActions.Hashing(user.Password);

        if (IsUsesDeleted)
        {
            existUser = mapper.Map<User>(user);
            existUser.Id = id;
        }
        else
        {
            existUser = await userRepository.SelectAsync(id) ??
                throw new CustomException(404, "User is not found");
        }

        existUser.UpdatedAt = DateTime.UtcNow;
        var updatedUser = await userRepository.UpdateAsync(existUser);

        return mapper.Map<UserViewModel>(updatedUser);
    }
}