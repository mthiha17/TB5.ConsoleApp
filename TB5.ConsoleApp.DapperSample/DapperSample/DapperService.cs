using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB5.ConsoleApp.DapperSample.DapperSample
{
    public class DapperService
    {
        private String connectionString = "Data Source=dell\\MSSQLSERVER01;Initial Catalog=MiniPOS;User ID=sa;Password=sasa@123;Trust Server Certificate=True;";


        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([Name]
           ,[Price])
     VALUES
           (@Name
           ,@Price)";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new { Name = "Strawberry", Price = 500 });

            string message = result > 0 ? "Product created successfully." : "Failed to create product.";
            Console.WriteLine(message);
        }

        public void Read()
        {
            string query = "SELECT * FROM Tbl_Product";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            List<TblProduct> lst = connection.Query<TblProduct>(query).ToList();

            foreach (TblProduct item in lst)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
            }

        }

        public void Edit()
        {
            string query = "SELECT * FROM Tbl_Product Where Id=@Id;";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            var item = connection.Query<TblProduct>(query, new
            {
                Id = 7
            }).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine(item.Id);
            Console.WriteLine(item.Name);
            Console.WriteLine(item.Price);
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Product]
SET [Name] = @Name,
    [Price] = @Price
WHERE Id = @Id";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new
            {
                Id = 1,
                Name = "Banana",
                Price = 1000
            });

            connection.Close();

            string message = result > 0 ? "Product updated successfully." : "Failed to update product.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_Product]
WHERE Id = @Id";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new { Id = 1 });

            string message = result > 0 ? "Product deleted successfully." : "Failed to delete product.";
            Console.WriteLine(message);
        }
    }

    public class TblProduct
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }
    }
}
