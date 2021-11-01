using FMWebApITekMod10.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FMWebApITekMod10.Services
{
    public class CustomerDao
    {
        public CustomerDao()
        {
        }

        public bool AddCustomer(Customers customer)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = FleetManager; Integrated Security = True";
                bool success = false;
            string sqlStatement = "INSERT INTO dbo.Customers (FirstName, LastName, Address, Zip, City) VALUES (@FirstName, @LastName, @Address, @Zip, @City)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@FirstName", System.Data.SqlDbType.VarChar, int.MaxValue).Value = customer.FirstName;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.VarChar, int.MaxValue).Value = customer.LastName;
                command.Parameters.Add("@Address", System.Data.SqlDbType.VarChar, int.MaxValue).Value = customer.Address;
                command.Parameters.Add("@Zip", System.Data.SqlDbType.VarChar, int.MaxValue).Value = customer.Zip;
                command.Parameters.Add("@City", System.Data.SqlDbType.VarChar, int.MaxValue).Value = customer.City;

                try
                {
                    connection.Open();
                    int reader = command.ExecuteNonQuery();

                    if (reader > 0)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return success;
        }
    }
}
