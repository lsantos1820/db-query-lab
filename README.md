🔍 DB Query Lab — Consultas SQL em Banco de Dados usando C# e SQLite

Este Lab foi desenvolvido como parte da trilha .NET, com o objetivo de demonstrar como uma aplicação C# pode executar consultas SQL reais para análise de dados usando um banco local SQLite.

O projeto implementa na prática:

Criação de banco

Popular dados inicial

Consultas SQL com filtros

ADO.NET moderno

Repository Pattern

Estrutura profissional e reutilizável

Ideal para iniciantes e intermediários que desejam aprender SQL + C# em um cenário realista.

🧠 Conceitos Praticados
Área	Itens
Banco de Dados	SQLite, CREATE TABLE, INSERT, SELECT, WHERE, ORDER BY
C#	ADO.NET, Repository Pattern, Console App
SQL Seguro	Parâmetros (@Category, @MinPrice)
Arquitetura	Separação de responsabilidades
Versionamento	Git + GitHub
Análise de Dados	Consultas filtradas
🧱 Arquitetura do Projeto
DbQueryLab/
│
├── Models/
│   └── Product.cs
│
├── Data/
│   ├── DatabaseInitializer.cs
│   └── ProductRepository.cs
│
└── Program.cs

📌 Responsabilidade de cada parte

Product.cs → modelo que representa um registro na tabela

DatabaseInitializer.cs → cria o banco e popula dados

ProductRepository.cs → contém consultas SQL

Program.cs → interface com o usuário (menu interativo)

💡 Fluxo do Sistema (Visão Geral)

Programa inicia

Verifica se o banco existe

Não? → cria banco + tabela + dados

Instancia ProductRepository

Exibe menu de ações

Executa consultas SQL

Exibe resultados formatados

DbQueryLab/
│
├── Models/
│   └── Product.cs
│
├── Data/
│   ├── DatabaseInit
