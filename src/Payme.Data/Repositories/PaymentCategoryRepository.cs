using Payme.Data.IRepositories;
using Payme.Domain.Enitites.PaymentCategories;

namespace Payme.Data.Repositories;

public class PaymentCategoryRepository : IPaymentCategoryRepository
{
    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentCategory> InsertAsync(PaymentCategory paymentCategory)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PaymentCategory>> SelectAllAsEnumerable()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<PaymentCategory>> SelectAllAsQueryable()
    {
        throw new NotImplementedException();
    }

    public Task<PaymentCategory> SelectIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentCategory> UpdateAsync(long id, PaymentCategory paymentCategory)
    {
        throw new NotImplementedException();
    }
}
