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
                DeleteProduct(connection, "ProductToDelete");
                DeleteSupplier(connection, "SupplierToDelete");
                DeleteProductType(connection, "TypeToDelete");
            }
        }
        static void DeleteProduct(SqlConnection connection, string productName)
        {
            using (SqlCommand command = new SqlCommand($"DELETE FROM Products WHERE Product_Name = '{productName}'", connection))
            {
                command.ExecuteNonQuery();
            }
        }
        static void DeleteSupplier(SqlConnection connection, string supplierName)
        {
            using (SqlCommand command = new SqlCommand($"DELETE FROM Suppliers WHERE Supplier_Name = '{supplierName}'", connection))
            {
                command.ExecuteNonQuery();
            }
        }
        static void DeleteProductType(SqlConnection connection, string productType)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Products SET Product_Type = NULL WHERE Product_Type = '{productType}'", connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
