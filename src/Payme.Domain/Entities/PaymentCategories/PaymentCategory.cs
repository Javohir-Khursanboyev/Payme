using Payme.Domain.Commons;

namespace Payme.Domain.Entities.PaymentCategories;

/// <summary>
/// The PaymentCategory class represents a paymentCategory object that contains properties for paymentCategory data,
/// such as paymentCategory name.
/// It also inherits from the Auditable class.
public class PaymentCategory : Auditable
{
    /// <summary>
    /// The Name property represents the name for the paymentCategory.
    /// </summary>
    public string Name { get; set; }
}
