using Payme.Domain.Commons;

namespace Payme.Domain.Entities.PaymentCategories;

public class PaymentCategory : Auditable
{
    public string Name { get; set; }
}
