namespace Payme.Service.DTOs.Transactions;

public class TransactionViewModel
{
    public long Id { get; set; }
    public long SenderCardId { get; set; }
    public long ReceiverCardId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}
