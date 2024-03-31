using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Payme.Data.DbContexts;

public class DataSession
{
    private NpgsqlConnection connection;
    public DataSession(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        connection = new NpgsqlConnection(connectionString);
    }

    public async Task Init()
    {
        await InitTables();
    }

    private async Task InitTables()
    {
        string directoryPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            "Payme", "src", "Payme.Data", "Queries");

        var filePath = Path.Combine(directoryPath, "Tables.txt");

        var query = File.ReadAllText(filePath);
        await connection.ExecuteAsync(query);
    }
}