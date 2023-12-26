using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=LAPTOP-2;Initial Catalog=Warehouse;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                ShowAllProducts(connection);
                ShowAllProductTypes(connection);
                ShowAllSuppliers(connection);
                ShowProductWithMaxQuantity(connection);
                ShowProductWithMinQuantity(connection);
                ShowProductWithMinCost(connection);
                ShowProductWithMaxCost(connection);
            }
            Console.Read();
        }
        static void ShowAllProducts(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Products", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ID"]}, Product Name: {reader["Product_Name"]}, Product Type: {reader["Product_Type"]}");
                    }
                }
            }
        }
        static void ShowAllProductTypes(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT DISTINCT Product_Type FROM Products", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Type: {reader["Product_Type"]}");
                    }
                }
            }
        }
        static void ShowAllSuppliers(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Suppliers", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ID"]}, Supplier Name: {reader["Supplier_Name"]}");
                    }
                }
            }
        }
        static void ShowProductWithMaxQuantity(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 Product_ID, MAX(Quantity) as MaxQuantity FROM Warehouse GROUP BY Product_ID ORDER BY MaxQuantity DESC", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product ID: {reader["Product_ID"]}, Max Quantity: {reader["MaxQuantity"]}");
                    }
                }
            }
        }
        static void ShowProductWithMinQuantity(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 Product_ID, MIN(Quantity) as MinQuantity FROM Warehouse GROUP BY Product_ID ORDER BY MinQuantity ASC", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product ID: {reader["Product_ID"]}, Min Quantity: {reader["MinQuantity"]}");
                    }
                }
            }
        }
        static void ShowProductWithMinCost(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 Product_ID, MIN(Cost) as MinCost FROM Warehouse GROUP BY Product_ID ORDER BY MinCost ASC", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product ID: {reader["Product_ID"]}, Min Cost: {reader["MinCost"]}");
                    }
                }
            }
        }
        static void ShowProductWithMaxCost(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 Product_ID, MAX(Cost) as MaxCost FROM Warehouse GROUP BY Product_ID ORDER BY MaxCost DESC", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product ID: {reader["Product_ID"]}, Max Cost: {reader["MaxCost"]}");
                    }
                }
            }
        }
    }
}