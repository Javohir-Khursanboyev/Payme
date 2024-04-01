using Payme.Domain.Enums;

namespace Payme.Service.DTOs.Cards;

public class CardCreationModel
{
    public long CustomerId { get; set; }
    public CardType Type { get; set; }
    public long Number { get; set; }
    public string ExpiryDate { get; set; }
    public string Password { get; set; }
}
