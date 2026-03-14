using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB5.ConsoleApp.AdoDotNetSample
{
    // CRUD - Create, Read, Update, Delete  
    public class AdoDotNetService
    {
        // fields
        private string connectionString = "Data Source=.;Initial Catalog=Batch5MiniPOS;User ID=sa;Password=sasa@123;Trust Server Certificate=True;";

        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([Name]
           ,[Price])
     VALUES
           (@Name
           ,@Price)";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Name", "Strawberry");
            cmd.Parameters.AddWithValue("@Price", 500);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            //if else
            string message = result > 0 ? "Product created successfully." : "Failed to create product.";
            Console.WriteLine(message);
        }

        public void Read()
        {
            string query = "SELECT * FROM Tbl_Product";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            connection.Close();

            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["Id"]);
                string name = row["Name"].ToString()!;
                decimal price = Convert.ToDecimal(row["Price"]);

                Console.WriteLine($"Id: {id}, Name: {name}, Price: {price}");
            }
        }

        public void Edit()
        {
            string query = "SELECT * FROM Tbl_Product Where Id=@Id;";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", 0);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            DataRow row = dt.Rows[0];
            int id = Convert.ToInt32(row["Id"]);
            string name = row["Name"].ToString()!;
            decimal price = Convert.ToDecimal(row["Price"]);

            Console.WriteLine($"Id: {id}, Name: {name}, Price: {price}");
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Product]
SET [Name] = @Name,
    [Price] = @Price
WHERE Id = @Id";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", 1);
            cmd.Parameters.AddWithValue("@Name", "Banana");
            cmd.Parameters.AddWithValue("@Price", 1000);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Product updated successfully." : "Failed to update product.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            string query = @"DELETE FROM [dbo].[Tbl_Product]
WHERE Id = @Id";

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", 1);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

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

    public class TblSale
    {
        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime SaleDate { get; set; }
    }
}