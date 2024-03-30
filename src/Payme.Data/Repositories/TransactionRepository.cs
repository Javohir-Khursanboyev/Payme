using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.Transactions;

namespace Payme.Data.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly string? connectionString;

    public TransactionRepository(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<Transaction> InsertAsync(Transaction transaction)
    {
        var transactionQuery = @"INSERT INTO Transactions (SenderId, ReceiverId, Amount, CreatedAt, UpdatedAt, DeletedAt, IsDeleted) 
                             VALUES (@SenderId, @ReceiverId, @Amount, @CreatedAt, @UpdatedAt, @DeletedAt, @IsDeleted)
                             RETURNING Id";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            var id = await connection.ExecuteScalarAsync<long>(transactionQuery, transaction);
            transaction.Id = id;
        }
        return transaction;
    }

    public async Task<Transaction> UpdateAsync(Transaction transaction)
    {
        var transactionQuery = @"UPDATE Transactions SET SenderId = @SenderId, ReceiverId = @ReceiverId, 
                                                         Amount = @Amount, UpdatedAt = @UpdatedAt, IsDeleted = false
                                                     WHERE Id = @Id";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.ExecuteAsync(transactionQuery, transaction);
        }
        return transaction;
    }

    public async Task<bool> DeleteAsync(Transaction transaction)
    {
        var transactionQuery = @"UPDATE Transactions SET IsDeleted = false, 
                                                         DeletedAt = @DeletedAt 
                                                     WHERE Id = @Id";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.ExecuteAsync(transactionQuery, transaction);
        }
        return true;
    }

    public async Task<IEnumerable<Transaction>> SelectAllAsIEnumerableAsync()
    {
        var transactionQuery = "SELECT * FROM Transactions WHERE Id = @id AND IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            return await connection.QueryAsync<Transaction>(transactionQuery);
        }
    }

    public async Task<IQueryable<Transaction>> SelectAllIQueryableAsync()
    {
        var query = "SELECT * FROM Transactions WHERE IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            return (await connection.QueryAsync<Transaction>(query)).AsQueryable();
        }
    }

    public async Task<Transaction> SelectAsync(long id)
    {
        var query = "SELECT * FROM Transactions WHERE IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await connection.QueryFirstOrDefaultAsync<Transaction>(query, new { id = id });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
