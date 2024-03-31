using Payme.Domain.Commons;
using Payme.Domain.Entities.Cards;
using Payme.Domain.Entities.Payments;
using Payme.Domain.Entities.Users;

namespace Payme.Domain.Entities.UserPayments;

/// <summary>
/// The userPayment class represents a userPayment object that contains properties for userPayment data,
/// such as userPayment accountNumber, userPayment amount and additionalInformation.
/// It also contains properties for userPayment's related data, such as user, card, payment.
/// It also inherits from the Auditable class.
/// </summary>
public class UserPayment : Auditable
{
    /// <summary>
    /// The UserId property represents the id of user associated with the userPayment.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// The User property represents the object of the user associated with the userPayment.
    /// </summary>
    public User user { get; set; }

    /// <summary>
    /// The CardId property represents the id of card associated with the userPayment.
    /// </summary>
    public long CardId { get; set; }

    /// <summary>
    /// The Card property represents the object of the card associated with the userPayment.
    /// </summary>
    public Card Card { get; set; }

    /// <summary>
    /// The PaymentId property represents the id of payment associated with the userPayment.
    /// </summary>
    public long PaymentId { get; set; }

    /// <summary>
    /// The Payment property represents the object of the payment associated with the userPayment.
    /// </summary>
    public Payment Payment { get; set; }

    /// <summary>
    /// The AccountNumber property represents the accountNumber for the userPayment.
    /// </summary>
    public string AccountNumber { get; set; }

    /// <summary>
    /// The Amount property represents the amount for the userPayment.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// The AdditionalInformation property represents the additionalInformation for the userPayment.
    /// </summary>
    public string AdditionalInformation { get; set; }
}
