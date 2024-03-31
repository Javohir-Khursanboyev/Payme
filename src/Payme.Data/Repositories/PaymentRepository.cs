using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.Payments;

namespace Payme.Data.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly string? connectionString;
    public PaymentRepository(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public async Task<bool> DeleteAsync(Payment payment)
    {
        var query = @"UPDATE Payments 
                        SET IsDeleted = false, 
                            DeletedAt = @DeletedAt 
                        WHERE Id = @Id";
        using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.ExecuteAsync(query, payment);
        }
        return true;
    }

    public async Task<Payment> InsertAsync(Payment payment)
    {
        var query = @"INSERT INTO Payment(Name, PaymentCategoryId, CreatedAt, UpdatedAt, DeletedAt, IsDeleted)
                        Values(@Name, @PaymentCategoryId, @CreatedAt, @UpdatedAt, @DeletedAt, @IsDeleted)
                        RETURNING Id";
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var id = await connection.ExecuteScalarAsync<long>(query, payment);
            payment.Id = id;
        }
        return payment;
    }

    public async Task<IEnumerable<Payment>> SelectAllAsEnumerableAsync()
    {
        var query = "SELECT * FROM Payments WHERE Id = @id AND IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            return await connection.QueryAsync<Payment>(query);
        }
    }

    public async Task<IQueryable<Payment>> SelectAllAsQueryableAsync()
    {
        var query = "SELECT * FROM Payments WHERE Id = @id AND IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            return (await connection.QueryAsync<Payment>(query)).AsQueryable();
        }
    }

    public async Task<Payment> SelectAsync(long id)
    {
        var query = $"SELECT * FROM Payments WHERE IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await connection.QueryFirstOrDefaultAsync<Payment>(query, new { id = id });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    public async Task<Payment> UpdateAsync(Payment payment)
    {
        var query = @"UPDATE Payments SET Name = @Name
                             PaymentCategoryId = @PaymentCategoryId
                             UpdatedAt = @UpdatedAt, IsDeleted = false
                             WHERE Id = @Id";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.ExecuteAsync(query, payment);
        }
        return payment;
    }
}