using Payme.Domain.Commons;
using Payme.Domain.Enums;

namespace Payme.Domain.Entities.Users;

/// <summary>
/// The User class represents a user object that contains properties for user data,
/// such as user firstName, user lastName, user phone, password and role.
/// It also inherits from the Auditable class.
/// </summary>
public class User : Auditable
{
    /// <summary>
    /// The FirstName property represents the firstName for the user.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// The lastName property represents the lastName for the user.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// The Phone property represents the phone for the user.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// The Password property represents the password for the user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The Role property represents the role of the user.
    /// </summary>
    public Role Role { get; set; }
}
