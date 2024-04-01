using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.UserPayments;

namespace Payme.Data.Repositories;

public class UserPaymentRepository : IUserPaymentRepository
{
    private readonly string? connectionString;
    public UserPaymentRepository(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<UserPayment> InsertAsync(UserPayment userPayment)
    {
        var query = "INSERT INTO UserPayments (UserId, CardId, PaymentId, AccountNumber," +
            " Amount, AdditionalInformation, CreatedAt, UpdatedAt, DeletedAt, IsDeleted) " +
            " VALUES (@UserId, @CardId, @PaymentId, @AccountNumber, @Amount, @AdditionalInformation," +
            " @CreatedAt, @UpdatedAt, @DeletedAt, @IsDeleted)";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            var id = await connection.ExecuteScalarAsync<long>(query, userPayment);
            userPayment.Id = id;
        }
        return userPayment;
    }

    public Task<UserPayment> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserPayment> SelectAsync(long id)
    {
        var query = "SELECT * FROM UserPayments WHERE IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await connection.QueryFirstOrDefaultAsync<UserPayment>(query, new { id = id });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }

    public async Task<IEnumerable<UserPayment>> SelectAsIEnumerableAsync()
    {
        var query = "SELECT * FROM UserPayments WHERE IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            return await connection.QueryAsync<UserPayment>(query);
        }
    }

    public async Task<IEnumerable<UserPayment>> SelectAsIQueryableAsync()
    {
        var query = "SELECT * FROM UserPayments WHERE IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            return (await connection.QueryAsync<UserPayment>(query)).AsQueryable();
        }
    }
}
