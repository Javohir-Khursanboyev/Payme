using Payme.Domain.Entities.Transactions;

namespace Payme.Data.IRepositories;

public interface ITransactionRepository
{
    Task<Transaction> InsertAsync(Transaction transaction);
    Task<Transaction> UpdateAsync(Transaction transaction);
    Task<Transaction> SelectAsync(long id);
    Task<bool> DeleteAsync(Transaction transaction);
    Task<IEnumerable<Transaction>> SelectAllAsIEnumerableAsync();
    Task<IQueryable<Transaction>> SelectAllIQueryableAsync();
}
