using DbQueryLab.Models;
using Microsoft.Data.Sqlite;

namespace DbQueryLab.Data;

public class ProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Product> GetAll()
    {
        const string sql = "SELECT Id, Name, Category, Price FROM Products ORDER BY Name;";

        var products = new List<Product>();

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var cmd = new SqliteCommand(sql, connection);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            products.Add(new Product
            {
                Id = reader.GetInt64(0),
                Name = reader.GetString(1),
                Category = reader.GetString(2),
                Price = (decimal)reader.GetDouble(3)
            });
        }

        return products;
    }

    public List<Product> GetByCategory(string category)
    {
        const string sql = @"
            SELECT Id, Name, Category, Price 
            FROM Products 
            WHERE Category = @Category
            ORDER BY Price DESC;
        ";

        var products = new List<Product>();

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@Category", category);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            products.Add(new Product
            {
                Id = reader.GetInt64(0),
                Name = reader.GetString(1),
                Category = reader.GetString(2),
                Price = (decimal)reader.GetDouble(3)
            });
        }

        return products;
    }

    public List<Product> GetByMinPrice(decimal minPrice)
    {
        const string sql = @"
            SELECT Id, Name, Category, Price
            FROM Products
            WHERE Price >= @MinPrice
            ORDER BY Price DESC;
        ";

        var products = new List<Product>();

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var cmd = new SqliteCommand(sql, connection);
        cmd.Parameters.AddWithValue("@MinPrice", (double)minPrice);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            products.Add(new Product
            {
                Id = reader.GetInt64(0),
                Name = reader.GetString(1),
                Category = reader.GetString(2),
                Price = (decimal)reader.GetDouble(3)
            });
        }

        return products;
    }
}
