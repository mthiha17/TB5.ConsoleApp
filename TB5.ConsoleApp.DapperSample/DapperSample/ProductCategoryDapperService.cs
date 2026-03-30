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
    public class ProductCategoryDapperService
    {
        private String connectionString = "Data Source=dell\\MSSQLSERVER01;Initial Catalog=MiniPOS;User ID=sa;Password=sasa@123;Trust Server Certificate=True;";

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_ProductCategory]
           ([ProductCategoryName])
     VALUES
           (@ProductCategoryName)";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new
            {
                ProductCategoryName = "Beverages"
            });

            string message = result > 0 ? "Product Category created successfully." : "Failed to create product category.";
            Console.WriteLine(message);
        }

        public void Read()
        {
            string query = "SELECT * FROM Tbl_ProductCategory";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            List<TblProductCategory> lst = connection.Query<TblProductCategory>(query).ToList();

            foreach (TblProductCategory item in lst)
            {
                Console.WriteLine($"ProductCategoryId: {item.ProductCategoryId}, ProductCategoryName: {item.ProductCategoryName}");
            }
        }

        public void Edit()
        {
            string query = "SELECT * FROM Tbl_ProductCategory Where ProductCategoryId=@ProductCategoryId;";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            var item = connection.Query<TblProductCategory>(query, new
            {
                ProductCategoryId = 1
            }).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("Product Category not found.");
                return;
            }

            Console.WriteLine($"ProductCategoryId: {item.ProductCategoryId}, ProductCategoryName: {item.ProductCategoryName}");
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_ProductCategory]
SET [ProductCategoryName] = @ProductCategoryName
WHERE ProductCategoryId = @ProductCategoryId";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new
            {
                ProductCategoryId = 1,
                ProductCategoryName = "Snacks"
            });

            string message = result > 0 ? "Product Category updated successfully." : "Failed to update product category.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_ProductCategory]
WHERE ProductCategoryId = @ProductCategoryId";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new { ProductCategoryId = 1 });

            string message = result > 0 ? "Product Category deleted successfully." : "Failed to delete product category.";
            Console.WriteLine(message);
        }
    }

    public class TblProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; } = null!;
    }
}
