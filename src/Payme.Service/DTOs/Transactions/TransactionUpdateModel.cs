namespace Payme.Service.DTOs.Transactions;

public class TransactionUpdateModel
{
    public long SenderCardId { get; set; }
    public long ReceiverCardId { get; set; }
    public decimal Amount { get; set; }
}
