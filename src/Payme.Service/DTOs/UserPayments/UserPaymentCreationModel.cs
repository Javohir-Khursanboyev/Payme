﻿namespace Payme.Service.DTOs.UserPayments;

public class UserPaymentCreationModel
{
    public long UserId { get; set; }
    public long CardId { get; set; }
    public long PaymentId { get; set; }
    public string AccountNumber { get; set; }
    public decimal Amount { get; set; }
    public string AdditionalInformation { get; set; }
}
