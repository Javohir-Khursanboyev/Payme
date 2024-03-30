using Payme.Domain.Entities.PaymentCategories;

namespace Payme.Data.IRepositories;

public interface IPaymentCategoryRepository
{
    Task<PaymentCategory> InsertAsync(PaymentCategory paymentCategory); 
    Task<PaymentCategory> UpdateAsync(long id, PaymentCategory paymentCategory);
    Task<bool> DeleteAsync (PaymentCategory paymentCategory);
    Task<PaymentCategory> SelectAsync (long id);
    Task<IEnumerable<PaymentCategory>> SelectAllAsEnumerable ();
    Task<IQueryable<PaymentCategory>> SelectAllAsQueryable ();
}
