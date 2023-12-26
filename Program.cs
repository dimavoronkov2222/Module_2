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
                UpdateProduct(connection, "ExistingProduct", "UpdatedName", "UpdatedType");
                UpdateSupplier(connection, "ExistingSupplier", "UpdatedSupplier");
                UpdateProductType(connection, "ExistingProduct", "UpdatedType");
            }
        }
        static void UpdateProduct(SqlConnection connection, string existingProductName, string updatedProductName, string updatedProductType)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Products SET Product_Name = '{updatedProductName}', Product_Type = '{updatedProductType}' WHERE Product_Name = '{existingProductName}'", connection))
            {
                command.ExecuteNonQuery();
            }
        }
        static void UpdateSupplier(SqlConnection connection, string existingSupplierName, string updatedSupplierName)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Suppliers SET Supplier_Name = '{updatedSupplierName}' WHERE Supplier_Name = '{existingSupplierName}'", connection))
            {
                command.ExecuteNonQuery();
            }
        }
        static void UpdateProductType(SqlConnection connection, string existingProductName, string updatedProductType)
        {
            using (SqlCommand command = new SqlCommand($"UPDATE Products SET Product_Type = '{updatedProductType}' WHERE Product_Name = '{existingProductName}'", connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }
}
