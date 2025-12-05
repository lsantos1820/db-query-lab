using Microsoft.Data.Sqlite;

namespace DbQueryLab.Data;

public static class DatabaseInitializer
{
    private const string DatabaseFile = "store.db";

    private static string ConnectionString =>
        new SqliteConnectionStringBuilder
        {
            DataSource = DatabaseFile
        }.ToString();

    public static string GetConnectionString() => ConnectionString;

    public static void EnsureDatabase()
    {
        if (!File.Exists(DatabaseFile))
        {
            Console.WriteLine("📁 Banco não encontrado. Criando banco SQLite e populando dados de exemplo...");

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var createTableSql = @"
                CREATE TABLE Products (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Category TEXT NOT NULL,
                    Price REAL NOT NULL
                );
            ";

            using (var cmd = new SqliteCommand(createTableSql, connection))
            {
                cmd.ExecuteNonQuery();
            }

            var insertSql = @"
                INSERT INTO Products (Name, Category, Price) VALUES 
                ('Teclado Mecânico', 'Periféricos', 350.00),
                ('Mouse Gamer', 'Periféricos', 220.00),
                ('Monitor 27 Polegadas', 'Monitores', 1200.00),
                ('Headset USB', 'Áudio', 180.00),
                ('Notebook i5 16GB', 'Computadores', 3800.00),
                ('Cadeira Gamer', 'Móveis', 900.00),
                ('Hub USB', 'Acessórios', 70.00);
            ";

            using (var cmd = new SqliteCommand(insertSql, connection))
            {
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("✅ Banco criado e populado com sucesso.\n");
        }
    }
}
