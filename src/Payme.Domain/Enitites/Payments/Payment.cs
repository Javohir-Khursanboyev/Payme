using Payme.Domain.Commons;
using Payme.Domain.Enitites.PaymentCategories;

namespace Payme.Domain.Enitites.Payments;

public class Payment : Auditable
{
    public string Name { get; set; }
    public long PaymentCategoryId { get; set; }
    public PaymentCategory PaymentCategory { get; set; }
}
