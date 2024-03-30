using Payme.Service.DTOs.Transactions;

namespace Payme.Service.Services.TransactionServices;

public interface ITransactionService
{
    Task<TransactionViewModel> CreateAsync(TransactionCreationModel transaction);
    Task<TransactionViewModel> GetByIdAsync(long id);
    Task<IEnumerable<TransactionViewModel>> GetAllAsync(long? id = null);
}
