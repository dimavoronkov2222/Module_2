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
                ShowProductsByCategory(connection, "YourCategory");
                ShowProductsBySupplier(connection, "YourSupplier");
                ShowOldestProductInWarehouse(connection);
                ShowAverageQuantityByProductType(connection);
                Console.Read();
            }
        }
        static void ShowProductsByCategory(SqlConnection connection, string category)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Products WHERE Product_Type = '{category}'", connection))
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
        static void ShowProductsBySupplier(SqlConnection connection, string supplier)
        {
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Products INNER JOIN Warehouse ON Products.ID = Warehouse.Product_ID INNER JOIN Suppliers ON Warehouse.Supplier_ID = Suppliers.ID WHERE Suppliers.Supplier_Name = '{supplier}'", connection))
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
        static void ShowOldestProductInWarehouse(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 Product_ID, MIN(Supply_Date) as OldestDate FROM Warehouse GROUP BY Product_ID ORDER BY OldestDate ASC", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product ID: {reader["Product_ID"]}, Oldest Supply Date: {reader["OldestDate"]}");
                    }
                }
            }
        }
        static void ShowAverageQuantityByProductType(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT Products.Product_Type, AVG(Warehouse.Quantity) as AverageQuantity FROM Products INNER JOIN Warehouse ON Products.ID = Warehouse.Product_ID GROUP BY Products.Product_Type", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Type: {reader["Product_Type"]}, Average Quantity: {reader["AverageQuantity"]}");
                    }
                }
            }
        }
    }
}
