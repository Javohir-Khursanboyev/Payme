using Payme.Domain.Commons;
using Payme.Domain.Enums;

namespace Payme.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
