using System;
using System.Collections.Generic;
using DbQueryLab.Data;
using DbQueryLab.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== 🔎 Lab de Consultas em Banco de Dados (SQLite + C#) ===\n");

// 1. Garante que o banco exista e tenha dados
DatabaseInitializer.EnsureDatabase();

// 2. Cria o repositório com a connection string
var connectionString = DatabaseInitializer.GetConnectionString();
var repository = new ProductRepository(connectionString);

while (true)
{
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1 - Listar todos os produtos");
    Console.WriteLine("2 - Listar produtos por categoria");
    Console.WriteLine("3 - Listar produtos por preço mínimo");
    Console.WriteLine("0 - Sair");
    Console.Write("Opção: ");
    var opcao = Console.ReadLine();

    Console.WriteLine();

    switch (opcao)
    {
        case "1":
            ListarTodos(repository);
            break;

        case "2":
            ListarPorCategoria(repository);
            break;

        case "3":
            ListarPorPreco(repository);
            break;

        case "0":
            Console.WriteLine("Encerrando... 👋");
            return;

        default:
            Console.WriteLine("Opção inválida.\n");
            break;
    }
}

static void ListarTodos(ProductRepository repository)
{
    var produtos = repository.GetAll();

    Console.WriteLine("📋 Lista de produtos (todos):\n");
    ExibirProdutos(produtos);
}

static void ListarPorCategoria(ProductRepository repository)
{
    Console.Write("Digite a categoria (ex: Periféricos, Monitores, Computadores): ");
    var category = Console.ReadLine() ?? string.Empty;

    var produtos = repository.GetByCategory(category);

    Console.WriteLine($"\n📋 Produtos da categoria '{category}':\n");
    ExibirProdutos(produtos);
}

static void ListarPorPreco(ProductRepository repository)
{
    Console.Write("Digite o preço mínimo (ex: 200, 500): ");
    var input = Console.ReadLine();

    if (!decimal.TryParse(input, out var minPrice))
    {
        Console.WriteLine("Valor inválido.\n");
        return;
    }

    var produtos = repository.GetByMinPrice(minPrice);

    Console.WriteLine($"\n📋 Produtos com preço >= R$ {minPrice:F2}:\n");
    ExibirProdutos(produtos);
}

static void ExibirProdutos(List<Product> produtos)
{
    if (produtos.Count == 0)
    {
        Console.WriteLine("Nenhum produto encontrado.\n");
        return;
    }

    foreach (var p in produtos)
    {
        Console.WriteLine(
            $"ID: {p.Id} | Nome: {p.Name} | Categoria: {p.Category} | Preço: R$ {p.Price:F2}");
    }

    Console.WriteLine();
}
