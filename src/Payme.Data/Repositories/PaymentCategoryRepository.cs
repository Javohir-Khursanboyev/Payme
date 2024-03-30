using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.PaymentCategories;
namespace Payme.Data.Repositories;

public class PaymentCategoryRepository : IPaymentCategoryRepository
{
    private readonly string? connectionString;
    public PaymentCategoryRepository(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<PaymentCategory> InsertAsync(PaymentCategory paymentCategory)
    {
        var query = @"INSERT INTO PaymentCategories(Name) Values (@Name) RETURNING Id";
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var id = await connection.ExecuteScalarAsync<long>(query, paymentCategory);
            paymentCategory.Id = id;
        }
        return paymentCategory;
    }

    public async Task<PaymentCategory> UpdateAsync(long id, PaymentCategory paymentCategory)
    {
        var query = @"UPDATE PaymentCategories SET Name = @Name
                             UpdatedAt = @UpdatedAt, IsDeleted = false
                             WHERE Id = @Id";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.ExecuteAsync(query, paymentCategory);
        }
        return paymentCategory;
    }


    public async Task<bool> DeleteAsync(PaymentCategory paymentCategory)
    {
        var query = @"UPDATE PaymentCategories 
                        SET IsDeleted = false, 
                            DeletedAt = @DeletedAt 
                        WHERE Id = @Id";
        using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.ExecuteAsync(query, paymentCategory);
        }
        return true;

    }

    public async Task<PaymentCategory> SelectAsync(long id)
    {
        var query = $"SELECT * FROM PaymentCategories WHERE IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await connection.QueryFirstOrDefaultAsync<PaymentCategory>(query, new { id = id });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    public async Task<IEnumerable<PaymentCategory>> SelectAllAsEnumerable()
    {
        var query = "SELECT * FROM PaymentCategories WHERE Id = @id AND IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            return await connection.QueryAsync<PaymentCategory>(query);
        }
    }

    public async Task<IQueryable<PaymentCategory>> SelectAllAsQueryable()
    {
        var query = "SELECT * FROM PaymentCategories WHERE Id = @id AND IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            return (await connection.QueryAsync<PaymentCategory>(query)).AsQueryable();
        }
    }
}
