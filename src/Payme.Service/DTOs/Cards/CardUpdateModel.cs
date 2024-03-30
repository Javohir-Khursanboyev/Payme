using Payme.Domain.Enums;

namespace Payme.Service.DTOs.Cards;

public class CardUpdateModel
{
    public long CustomerId { get; set; }
    public CardType Type { get; set; }
    public long Number { get; set; }
    public string ExpiryData { get; set; }
    public string Password { get; set; }
}
