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
    public class SaleDapperService
    {
        private String connectionString = "Data Source=dell\\MSSQLSERVER01;Initial Catalog=MiniPOS;User ID=sa;Password=sasa@123;Trust Server Certificate=True;";

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Sale]
           ([ProductId]
           ,[Price]
           ,[Quantity]
           ,[SaleDate])
     VALUES
           (@ProductID
           ,@Price
           ,@Quantity
           ,@SaleDate)";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new
            {
                ProductID = 1,
                Price = 1000,
                Quantity = 2,
                SaleDate = DateTime.Now
            });

            string message = result > 0 ? "Sale created successfully." : "Failed to create sale.";
            Console.WriteLine(message);
        }

        public void Read()
        {
            string query = "SELECT * FROM Tbl_Sale";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            List<TblSale> lst = connection.Query<TblSale>(query).ToList();

            foreach (TblSale item in lst)
            {
                Console.WriteLine($"SaleID: {item.SaleID}, ProductID: {item.ProductID}, Price: {item.Price}, Quantity: {item.Quantity}, SaleDate: {item.SaleDate}");
            }
        }

        public void Edit()
        {
            string query = "SELECT * FROM Tbl_Sale Where SaleId=@SaleID;";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            var item = connection.Query<TblSale>(query, new
            {
                SaleID = 1
            }).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("Sale not found.");
                return;
            }

            Console.WriteLine($"SaleID: {item.SaleID}, ProductID: {item.ProductID}, Price: {item.Price}, Quantity: {item.Quantity}, SaleDate: {item.SaleDate}");
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Sale]
SET [ProductID] = @ProductID,
    [Price] = @Price,
    [Quantity] = @Quantity,
    [SaleDate] = @SaleDate
WHERE SaleID = @SaleID";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new
            {
                SaleID = 1,
                ProductID = 1,
                Price = 1500,
                Quantity = 5,
                SaleDate = DateTime.Now
            });

            string message = result > 0 ? "Sale updated successfully." : "Failed to update sale.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_Sale]
WHERE SaleID = @SaleID";

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();

            int result = connection.Execute(query, new { SaleID = 1 });

            string message = result > 0 ? "Sale deleted successfully." : "Failed to delete sale.";
            Console.WriteLine(message);
        }
    }

    public class TblSale
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
