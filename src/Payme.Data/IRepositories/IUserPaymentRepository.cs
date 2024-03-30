using Payme.Domain.Entities.UserPayments;

namespace Payme.Data.IRepositories;

public interface IUserPaymentRepository
{
    Task<UserPayment> InsertAsync(UserPayment userPayment);
    Task<UserPayment> SelectAsync(long id);
    Task<UserPayment> DeleteAsync(long id);
    Task<IEnumerable<UserPayment>> SelectAsIEnumerableAsync();
    Task<IEnumerable<UserPayment>> SelectAsIQueryableAsync();
}
