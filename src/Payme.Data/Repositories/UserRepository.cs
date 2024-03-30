using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
                             VALUES (@FirstName, @LastName, @Phone, @Password, @Role, @CreatedAt, @UpdatedAt, @DeletedAt, @IsDeleted);";

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.ExecuteAsync(query, user);
        }
        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var query = @"UPDATE Users SET FirstName = @FirstName, LastName = @LastName, 
                             Phone = @Phone, Password = @Password, Role = @Role,
                             UpdatedAt = @UpdatedAt, IsDeleted = 1
                             WHERE Id = @Id";

        using (var connection = new SqlConnection(connectionString))
        {
            await connection.ExecuteAsync(query, user);
        }
        return user;
    }
    public async Task<bool> DeleteAsync(User user)
    {
        var query = @"UPDATE Users 
                        SET IsDeleted = 1, 
                            DeletedAt = @DeletedAt 
                        WHERE Id = @Id";

        using (var connection = new SqlConnection(connectionString))
        {
             await connection.ExecuteAsync(query, user);
        }
        return true;
    }
    public async Task<IEnumerable<User>> SelectAllAsIEnumerable()
    {
        var query = "SELECT * FROM Users";
        
        using (var connection = new SqlConnection(connectionString))
        {
            return (await connection.QueryAsync<User>(query)).ToList();
        }
    }

    public async Task<IQueryable<User>> SelectAllIQueryable()
    {
        var query = "SELECT * FROM Users";

        using (var connection = new SqlConnection(connectionString))
        {
            return (await connection.QueryAsync<User>(query)).AsQueryable();
        }
    }

    public async Task<User> SelectAsync(long id)
    {
        var query = "SELECT * FROM Users WHERE Id = @id";

        using (var connection = new SqlConnection(connectionString))
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await connection.QueryFirstOrDefaultAsync<User>(query,new { id = id });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
