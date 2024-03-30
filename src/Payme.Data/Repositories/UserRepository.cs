using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Payme.Data.IRepositories;
using Payme.Domain.Entities.Users;

namespace Payme.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string? connectionString;
    public UserRepository(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<User> InsertAsync(User user)
    {
        var query = @"INSERT INTO Users (FirstName, LastName, Phone, Password, Role, CreatedAt, UpdatedAt, DeletedAt, IsDeleted) 
                             VALUES (@FirstName, @LastName, @Phone, @Password, @Role, @CreatedAt, @UpdatedAt, @DeletedAt, @IsDeleted)
                             RETURNING Id";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            var id = await connection.ExecuteScalarAsync<long>(query, user);
            user.Id = id;
        }
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var query = @"UPDATE Users SET FirstName = @FirstName, LastName = @LastName, 
                             Phone = @Phone, Password = @Password, Role = @Role,
                             UpdatedAt = @UpdatedAt, IsDeleted = false
                             WHERE Id = @Id";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.ExecuteAsync(query, user);
        }
        return user;
    }
    public async Task<bool> DeleteAsync(User user)
    {
        var query = @"UPDATE Users 
                        SET IsDeleted = false, 
                            DeletedAt = @DeletedAt 
                        WHERE Id = @Id";

        using (var connection = new NpgsqlConnection(connectionString))
        {
             await connection.ExecuteAsync(query, user);
        }
        return true;
    }
    public async Task<IEnumerable<User>> SelectAllAsIEnumerableAsync()
    {
        var query = "SELECT * FROM Users WHERE Id = @id AND IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            return await connection.QueryAsync<User>(query);
        }
    }

    public async Task<IQueryable<User>> SelectAllIQueryableAsync()
    {
        var query = "SELECT * FROM Users WHERE IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            return (await connection.QueryAsync<User>(query)).AsQueryable();
        }
    }

    public async Task<User> SelectAsync(long id)
    {
        var query = "SELECT * FROM Users WHERE IsDeleted = false";

        using (var connection = new NpgsqlConnection(connectionString))
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await connection.QueryFirstOrDefaultAsync<User>(query,new { id = id });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
