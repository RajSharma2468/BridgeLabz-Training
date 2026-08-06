using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using SimpleCrudAPI.Entity;

namespace SimpleCrudAPI.Services
{
    // Handles product CRUD operations
    public class ProductService
    {
        // Connection string for database
        private readonly string connectionString =
            @"Server=.\SQLEXPRESS;Database=SimpleCrudDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // CREATE: Adds new product
        public void AddProduct(Product p)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)", conn))
            {
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Quantity", p.Quantity);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // READ: Gets all products
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT ProductId, Name, Price, Quantity FROM Products", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.ProductId = (int)reader["ProductId"];
                        p.Name = reader["Name"].ToString();
                        p.Price = (decimal)reader["Price"];
                        p.Quantity = (int)reader["Quantity"];
                        products.Add(p);
                    }
                }
            }
            return products;
        }

        // READ: Gets single product by id
        public Product GetProductById(int id)
        {
            Product p = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT ProductId, Name, Price, Quantity FROM Products WHERE ProductId = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        p = new Product();
                        p.ProductId = (int)reader["ProductId"];
                        p.Name = reader["Name"].ToString();
                        p.Price = (decimal)reader["Price"];
                        p.Quantity = (int)reader["Quantity"];
                    }
                }
            }
            return p;
        }

        // UPDATE: Modifies existing product
        public void UpdateProduct(Product p)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE ProductId = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
                cmd.Parameters.AddWithValue("@Id", p.ProductId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE: Removes a product
        public void DeleteProduct(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductId = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}