using System;
using Dapper;
using DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
  class Program
  {
    static void Main(string[] args)
    {
      const string connectionString = "Server=localhost,1433;Database=tutorialDapper;User ID=sa;Password=@Root1234";

      using (var connection = new SqlConnection(connectionString))
      {
        CreateManyCategories(connection);
      }
    }

    static void CreateManyCategories(SqlConnection connection)
    {
      var category01 = new Category();
      category01.Id = Guid.NewGuid();
      category01.Title = "Categoria 01";
      category01.Url = "categoria_01_url";
      category01.Description = "Criaçõa da categoria 01";
      category01.Order = 8;
      category01.Summary = "Nova categoria 01";
      category01.Featured = false;

      var category02 = new Category();
      category02.Id = Guid.NewGuid();
      category02.Title = "Categoria 02";
      category02.Url = "categoria_02_url";
      category02.Description = "Criaçõa da categoria 02";
      category02.Order = 9;
      category02.Summary = "Nova categoria 02";
      category02.Featured = true;

      var query = @"INSERT INTO [Category] 
      VALUES(
        @Id,
        @Title,
        @Url,
        @Summary,
        @Order,
        @Description,
        @Featured)";

      var rows = connection.Execute(query, new[]
      {
        new
        {
          category01.Id,
          category01.Title,
          category01.Url,
          category01.Summary,
          category01.Order,
          category01.Description,
          category01.Featured
        },
        new
        {
          category02.Id,
          category02.Title,
          category02.Url,
          category02.Summary,
          category02.Order,
          category02.Description,
          category02.Featured
        }
      });

      Console.WriteLine($"{rows} linhas inseridas");
    }
  }
}
