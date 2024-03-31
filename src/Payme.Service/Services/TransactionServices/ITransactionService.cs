using Payme.Service.DTOs.Transactions;

namespace Payme.Service.Services.TransactionServices;

public interface ITransactionService
{
    /// <summary>
    /// Creates a new transaction.
    /// </summary>
    /// <param name="transaction">The transaction creation model.</param>
    /// <returns>The created transaction view model.</returns>
    Task<TransactionViewModel> CreateAsync(TransactionCreationModel transaction);


    /// <summary>
    /// Retrieves a transaction by ID.
    /// </summary>
    /// <param name="id">The ID of the transaction to retrieve.</param>
    /// <returns>The transaction view model if found; otherwise, null.</returns>
    Task<TransactionViewModel> GetByIdAsync(long id);


    /// <summary>
    /// Retrieves all transactions or transactions for a specific ID.
    /// </summary>
    /// <param name="id">Optional. The ID of the transaction to retrieve.</param>
    /// <returns>A collection of transaction view models.</returns>
    Task<IEnumerable<TransactionViewModel>> GetAllAsync(long? id = null);
}