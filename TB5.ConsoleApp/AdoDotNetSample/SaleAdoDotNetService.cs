using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB5.ConsoleApp.AdoDotNetSample
{
    public class SaleAdoDotNetService
    {
        private String connectionString = "Data Source=dell\\MSSQLSERVER01;Initial Catalog=MiniPOS;User ID=sa;Password=sasa@123;Trust Server Certificate=True;";

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Sale]
           ([ProductID]
           ,[Price]
           ,[Quantity]
           ,[SaleDate])
     VALUES
           (@ProductID
           ,@Price
           ,@Quantity
           ,@SaleDate)";

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProductID", 1);
            cmd.Parameters.AddWithValue("@Price", 1000);
            cmd.Parameters.AddWithValue("@Quantity", 2);
            cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Sale created successfully." : "Failed to create sale.";
            Console.WriteLine(message);
        }

        public void Read()
        {
            string query = "SELECT * FROM Tbl_Sale";

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            connection.Close();

            foreach (DataRow row in dt.Rows)
            {
                int saleID = Convert.ToInt32(row["SaleID"]);
                int productID = Convert.ToInt32(row["ProductID"]);
                decimal price = Convert.ToDecimal(row["Price"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                DateTime saleDate = Convert.ToDateTime(row["SaleDate"]);

                Console.WriteLine($"SaleID: {saleID}, ProductID: {productID}, Price: {price}, Quantity: {quantity}, SaleDate: {saleDate}");
            }
        }

        public void Edit()
        {
            string query = "SELECT * FROM Tbl_Sale Where SaleId=@SaleId;";

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@SaleID", 1);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Sale not found.");
                return;
            }

            DataRow row = dt.Rows[0];
            int saleID = Convert.ToInt32(row["SaleID"]);
            int productID = Convert.ToInt32(row["ProductID"]);
            decimal price = Convert.ToDecimal(row["Price"]);
            int quantity = Convert.ToInt32(row["Quantity"]);
            DateTime saleDate = Convert.ToDateTime(row["SaleDate"]);

            Console.WriteLine($"SaleId: {saleID}, ProductId: {productID}, Price: {price}, Quantity: {quantity}, SaleDate: {saleDate}");
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Sale]
SET [ProductID] = @ProductID,
    [Price] = @Price,
    [Quantity] = @Quantity,
    [SaleDate] = @SaleDate
WHERE SaleId = @SaleId";

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@SaleID", 1);
            cmd.Parameters.AddWithValue("@ProductID", 1);
            cmd.Parameters.AddWithValue("@Price", 1200);
            cmd.Parameters.AddWithValue("@Quantity", 3);
            cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Sale updated successfully." : "Failed to update sale.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_Sale]
WHERE SaleID = @SaleID";

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@SaleID", 1);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Sale deleted successfully." : "Failed to delete sale.";
            Console.WriteLine(message);
        }
    }
}
