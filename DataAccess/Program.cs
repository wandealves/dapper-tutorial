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
        var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

        foreach (var category in categories)
        {
          Console.WriteLine($"{category.Id} - {category.Title}");
        }
      }
    }
  }
}
