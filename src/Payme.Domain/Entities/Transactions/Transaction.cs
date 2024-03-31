using Payme.Domain.Commons;
using Payme.Domain.Entities.Cards;

namespace Payme.Domain.Entities.Transactions;

/// <summary>
/// The Transaction class represents a transaction object that contains properties for transaction data,
/// such as transaction amount and password.
/// It also contains properties for transaction's related data, such as card.
/// It also inherits from the Auditable class.
public class Transaction : Auditable
{
    /// <summary>
    /// The SenderCardId property represents the id of card associated with the transaction.
    /// </summary>
    public long SenderCardId { get; set; }

    /// <summary>
    /// The SenderCard property represents the object of the card associated with the transaction.
    /// </summary>
    public Card SenderCard { get; set; }

    /// <summary>
    /// The ReceiverId property represents the id of card associated with the transaction.
    /// </summary>
    public long ReceiverCardId { get; set; }

    /// <summary>
    /// The ReceiverCard property represents the object of the card associated with the transaction.
    /// </summary>
    public Card ReceiverCard { get; set; }

    /// <summary>
    /// The Amount property represents the amount for the transaction.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// The Password property represents the password for the transaction.
    /// </summary>
    public string Password { get; set; }
}
