using Payme.Service.DTOs.Users;

namespace Payme.Service.Services.UserServices;

public interface IUserService
{
    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="user">The user creation model.</param>
    /// <returns>The created user view model.</returns>
    Task<UserViewModel> CreateAsync(UserCreationModel user);


    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="id">The ID of the user to update.</param>
    /// <param name="user">The user update model.</param>
    /// <param name="isUsesDeleted">Optional. Indicates if the user is marked as deleted.</param>
    /// <returns>The updated user view model.</returns>
    Task<UserViewModel> UpdateAsync(long id, UserUpdateModel user, bool isUsesDeleted = false);


    /// <summary>
    /// Retrieves a user by ID.
    /// </summary>
    /// <param name="id">The ID of the user to retrieve.</param>
    /// <returns>The user view model if found; otherwise, null.</returns>
    Task<UserViewModel> GetByIdAsync(long id);


    /// <summary>
    /// Deletes a user by ID.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    Task<bool> DeleteAsync(long id);


    /// <summary>
    /// Retrieves all users.
    /// </summary>
    /// <returns>A collection of user view models.</returns>
    Task<IEnumerable<UserViewModel>> GetAllAsync();
}