using Payme.Domain.Enitites.PaymentCategories;
using Payme.Domain.Enitites.Payments;

namespace Payme.Data.IRepositories;

public interface IPaymentCategoryRepository
{
    Task<PaymentCategory> InsertAsync(PaymentCategory paymentCategory); 
    Task<PaymentCategory> UpdateAsync(long id, PaymentCategory paymentCategory);
    Task<bool> DeleteAsync (long id);
    Task<PaymentCategory> SelectIdAsync (long id);
    Task<IEnumerable<PaymentCategory>> SelectAllAsEnumerable ();
    Task<IQueryable<PaymentCategory>> SelectAllAsQueryable ();
    Task SaveAsync();
}
