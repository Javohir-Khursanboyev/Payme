using Payme.Domain.Commons;
using Payme.Domain.Enitites.Payments;
using Payme.Domain.Enitites.Users;

namespace Payme.Domain.Enitites.UserPayments;

public class UserPayment : Auditable
{
    public long UserId { get; set; }
    public User user { get; set; }
    public long CardId { get; set; }
    public Card Card { get; set; }
    public long PaymentId { get; set; }
    public Payment Payment { get; set; }
    public string AccountNumber { get; set; }
    public decimal Amount { get; set; }
    public string AdditionalInformation { get; set; }
}
