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
                ShowSupplierWithMostProducts(connection);
                ShowSupplierWithLeastProducts(connection);
                ShowProductTypeWithMostQuantity(connection);
                ShowProductTypeWithLeastQuantity(connection);
                ShowProductsSuppliedBeforeDays(connection, 30);
                Console.Read();
            }
        }
        static void ShowSupplierWithMostProducts(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 Suppliers.Supplier_Name, COUNT(*) as ProductCount FROM Suppliers INNER JOIN Warehouse ON Suppliers.ID = Warehouse.Supplier_ID GROUP BY Suppliers.Supplier_Name ORDER BY ProductCount DESC", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Supplier Name: {reader["Supplier_Name"]}, Product Count: {reader["ProductCount"]}");
                    }
                }
            }
        }
        static void ShowSupplierWithLeastProducts(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 Suppliers.Supplier_Name, COUNT(*) as ProductCount FROM Suppliers INNER JOIN Warehouse ON Suppliers.ID = Warehouse.Supplier_ID GROUP BY Suppliers.Supplier_Name ORDER BY ProductCount ASC", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Supplier Name: {reader["Supplier_Name"]}, Product Count: {reader["ProductCount"]}");
                    }
                }
            }
        }
        static void ShowProductTypeWithMostQuantity(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 Products.Product_Type, SUM(Warehouse.Quantity) as TotalQuantity FROM Products INNER JOIN Warehouse ON Products.ID = Warehouse.Product_ID GROUP BY Products.Product_Type ORDER BY TotalQuantity DESC", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Type: {reader["Product_Type"]}, Total Quantity: {reader["TotalQuantity"]}");
                    }
                }
            }
        }
        static void ShowProductTypeWithLeastQuantity(SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand("SELECT TOP 1 Products.Product_Type, SUM(Warehouse.Quantity) as TotalQuantity FROM Products INNER JOIN Warehouse ON Products.ID = Warehouse.Product_ID GROUP BY Products.Product_Type ORDER BY TotalQuantity ASC", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Type: {reader["Product_Type"]}, Total Quantity: {reader["TotalQuantity"]}");
                    }
                }
            }
        }
        static void ShowProductsSuppliedBeforeDays(SqlConnection connection, int days)
        {
            using (SqlCommand command = new SqlCommand($"SELECT Products.Product_Name, Warehouse.Supply_Date FROM Products INNER JOIN Warehouse ON Products.ID = Warehouse.Product_ID WHERE DATEDIFF(DAY, Warehouse.Supply_Date, GETDATE()) > {days}", connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product Name: {reader["Product_Name"]}, Supply Date: {reader["Supply_Date"]}");
                    }
                }
            }
        }
    }
}
