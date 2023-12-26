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

                InsertNewProduct(connection, "NewProduct", "NewType");
                InsertNewSupplier(connection, "NewSupplier");
            }
            Console.Read();
        }
        static void InsertNewProduct(SqlConnection connection, string productName, string productType)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Products (Product_Name, Product_Type) VALUES ('{productName}', '{productType}')", connection))
            {
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Inserted {rowsAffected} row(s) into Products.");
            }
        }
        static void InsertNewSupplier(SqlConnection connection, string supplierName)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO Suppliers (Supplier_Name) VALUES ('{supplierName}')", connection))
            {
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Inserted {rowsAffected} row(s) into Suppliers.");
            }
        }
    }
}
