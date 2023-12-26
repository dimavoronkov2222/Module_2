using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace Module_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=LAPTOP-2;Initial Catalog=Warehouse;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("The connection to the \"Warehouse\" database has been successfully established.");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Database connection error: " + ex.Message);
                }
            }
            Console.WriteLine("The connection to the \"Warehouse\" database is closed.");
        }
    }
}