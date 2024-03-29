using Payme.Domain.Commons;
using Payme.Domain.Enitites.Users;

namespace Payme.Domain.Enitites.Cards;

public class Card : Auditable
{
    public long CustomerId { get; set; }
    public User Customer { get; set; }
    public Type Type { get; set; }
    public long Number { get; set; }
    public string ExpiryData { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
}
