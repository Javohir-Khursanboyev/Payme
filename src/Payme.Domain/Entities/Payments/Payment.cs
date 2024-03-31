using Payme.Domain.Commons;
using Payme.Domain.Entities.PaymentCategories;

namespace Payme.Domain.Entities.Payments;

/// <summary>
/// The Payment class represents a payment object that contains properties for payment data,
/// such as payment name.
/// It also contains properties for payment's related data, such as paymentCategory.
/// It also inherits from the Auditable class.
public class Payment : Auditable
{
    /// <summary>
    /// The Name property represents the name for the payment.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The PaymentCategoryId property represents the id of paymentCategory associated with the payment.
    /// </summary>
    public long PaymentCategoryId { get; set; }

    /// <summary>
    /// The PaymentCategory property represents the object of the paymentCategory associated with the payment.
    /// </summary>
    public PaymentCategory PaymentCategory { get; set; }
}
