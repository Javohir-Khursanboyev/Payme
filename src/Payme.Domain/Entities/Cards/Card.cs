using Payme.Domain.Commons;
using Payme.Domain.Entities.Users;
using Payme.Domain.Enums;

namespace Payme.Domain.Entities.Cards;

/// <summary>
/// The Card class represents a card object that contains properties for card data,
/// such as card type, card number, card expiryData, password and balance.
/// It also contains properties for card's related data, such as user.
/// It also inherits from the Auditable class.
public class Card : Auditable
{
    /// <summary>
    /// The CustomerId property represents the id of user associated with the card.
    /// </summary>
    public long CustomerId { get; set; }

    /// <summary>
    /// The Customer property represents the object of the user associated with the card.
    /// </summary>
    public User Customer { get; set; }

    /// <summary>
    /// The Type property represents the cardType of the card.
    /// </summary>
    public CardType Type { get; set; }

    /// <summary>
    /// The Number property represents the number for the card.
    /// </summary>
    public long Number { get; set; }

    /// <summary>
    /// The ExpiryData property represents the expiryData for the card.
    /// </summary>
    public string ExpiryData { get; set; }

    /// <summary>
    /// The Password property represents the password for the card.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The Balance property represents the balance for the card.
    /// </summary>
    public decimal Balance { get; set; }
}
