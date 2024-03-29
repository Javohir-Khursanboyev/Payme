using Payme.Domain.Commons;

namespace Payme.Domain.Enitites.PaymentCategories;

public class PaymentCategory : Auditable
{
    public string Name { get; set; }
}
