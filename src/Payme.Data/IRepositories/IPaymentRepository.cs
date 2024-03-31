using Payme.Domain.Entities.Payments;

namespace Payme.Data.IRepositories;

public interface IPaymentRepository
{
    Task<Payment> InsertAsync(Payment payment);
    Task<Payment> UpdateAsync(Payment payment);
    Task<bool> DeleteAsync(Payment payment);
    Task<Payment> SelectAsync(long id);
    Task<IEnumerable<Payment>> SelectAllAsEnumerableAsync();
    Task<IQueryable<Payment>> SelectAllAsQueryableAsync();
}