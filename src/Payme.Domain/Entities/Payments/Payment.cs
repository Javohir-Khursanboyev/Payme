using Payme.Domain.Commons;
using Payme.Domain.Entities.PaymentCategories;

namespace Payme.Domain.Entities.Payments;

public class Payment : Auditable
{
    public string Name { get; set; }
    public long PaymentCategoryId { get; set; }
    public PaymentCategory PaymentCategory { get; set; }
}
