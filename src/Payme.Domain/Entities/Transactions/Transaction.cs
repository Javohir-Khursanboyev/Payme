using Payme.Domain.Commons;
using Payme.Domain.Entities.Cards;

namespace Payme.Domain.Entities.Transactions;

public class Transaction : Auditable
{
    public long SenderCardId { get; set; }
    public Card SenderCard { get; set; }
    public long ReceiverCardId { get; set; }
    public Card ReceiverCard { get; set; }
    public decimal Amount { get; set; }
}
