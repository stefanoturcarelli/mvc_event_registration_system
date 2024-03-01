using ERM_ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM_DAL
{
    public class RegistrationRepository
    {
        // Create a method to get all registrations from a specific EventId
        public List<Registration> GetAllRegistrations(int eventId)
        {
            // Create a list of registrations
            List<Registration> registrations = new List<Registration>();

            // Connect to the database and get all registrations with "using" statement
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                // Fire a SQL query (Stored Procedure) to get all registrations
                string commandText = "usp_GetAllRegistrations";

                // Create a new SqlCommand object and pass the command text and connection object
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);

                // Set the command type to stored procedure
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add a parameter to the SqlCommand object
                sqlCommand.Parameters.AddWithValue("@EventId", eventId);

                // Use SqlDataAdapter to fill the data from the database into a DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                // Create a new DataTable object
                DataTable dt = new DataTable();

                // At this point, the SqlDataAdapter will fire the SQL query and fill the DataTable with the data
                adapter.Fill(dt);

                // Convert ADO.NET DataTable to List of Registration objects
                // Loop through each row in the DataTable
                foreach (DataRow row in dt.Rows)
                {
                    // Create a new Registration object
                    Registration r = new Registration();

                    // Set the properties of the Registration object
                    r.EventId = Convert.ToInt32(row["EventId"]);
                    r.AttendeeFirstName = row["AttendeeFirstName"].ToString();
                    r.AttendeeLastName = row["AttendeeLastName"].ToString();
                    r.Email = row["Email"].ToString();
                    r.RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]);

                    // Add the Registration object to the list
                    registrations.Add(r);
                }


                // Return the list of registrations
                return registrations;
            }
        }

        // Create a method to get all registrations
        public List<Registration> GettAllRegistrations()
        {
            // Create a list of registrations
            List<Registration> registrations = new List<Registration>();

            // Connect to the database and get all registrations with "using" statement
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                // Fire a SQL query (Stored Procedure) to get all registrations
                string commandText = "usp_GetAllRegistrations";

                // Create a new SqlCommand object and pass the command text and connection object
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);

                // Set the command type to stored procedure
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Use SqlDataAdapter to fill the data from the database into a DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                // Create a new DataTable object
                DataTable dt = new DataTable();

                // At this point, the SqlDataAdapter will fire the SQL query and fill the DataTable with the data
                adapter.Fill(dt);

                // Convert ADO.NET DataTable to List of Registration objects
                // Loop through each row in the DataTable
                foreach (DataRow row in dt.Rows)
                {
                    // Create a new Registration object
                    Registration r = new Registration();

                    // Set the properties of the Registration object
                    r.EventId = Convert.ToInt32(row["EventId"]);
                    r.AttendeeFirstName = row["AttendeeFirstName"].ToString();
                    r.AttendeeLastName = row["AttendeeLastName"].ToString();
                    r.Email = row["Email"].ToString();
                    r.RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]);

                    // Add the Registration object to the list
                    registrations.Add(r);
                }

                // Return the list of registrations
                return registrations;
            }
        }

        // Create a method to add a new registration
        public bool AddRegistration(Registration registration)
        {
            // Connect to the database and add a new registration with "using" statement
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                // Fire a SQL query (Stored Procedure) to add a new registration
                string commandText = "usp_AddRegistration";

                // Create a new SqlCommand object and pass the command text and connection object
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);

                // Set the command type to stored procedure
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add parameters to the SqlCommand object
                sqlCommand.Parameters.AddWithValue("@RegistrationId", registration.RegistrationId);
                sqlCommand.Parameters.AddWithValue("@EventId", registration.EventId);
                sqlCommand.Parameters.AddWithValue("@AttendeeFirstName", registration.AttendeeFirstName);
                sqlCommand.Parameters.AddWithValue("@AttendeeLastName", registration.AttendeeLastName);
                sqlCommand.Parameters.AddWithValue("@Email", registration.Email);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);

                // Open the connection
                conn.Open();

                // Execute the SQL query
                int rowsAffected = sqlCommand.ExecuteNonQuery();

                // Close the connection
                conn.Close();

                // If the number of rows affected is greater than 0, return true
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Create a method to update a registration
        public bool UpdateRegistration(Registration registration)
        {
            // Connect to the database and update a registration with "using" statement
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                // Fire a SQL query (Stored Procedure) to update a registration
                string commandText = "usp_UpdateRegistration";

                // Create a new SqlCommand object and pass the command text and connection object
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);

                // Set the command type to stored procedure
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add parameters to the SqlCommand object
                sqlCommand.Parameters.AddWithValue("@RegistrationId", registration.RegistrationId);
                sqlCommand.Parameters.AddWithValue("@EventId", registration.EventId);
                sqlCommand.Parameters.AddWithValue("@AttendeeFirstName", registration.AttendeeFirstName);
                sqlCommand.Parameters.AddWithValue("@AttendeeLastName", registration.AttendeeLastName);
                sqlCommand.Parameters.AddWithValue("@Email", registration.Email);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);

                // Open the connection
                conn.Open();

                // Execute the SQL query
                int rowsAffected = sqlCommand.ExecuteNonQuery();

                // Close the connection
                conn.Close();

                // If the number of rows affected is greater than 0, return true
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Create a method to delete a registration
        public bool DeleteRegistration(int registrationId)
        {
            // Connect to the database and delete a registration with "using" statement
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                // Fire a SQL query (Stored Procedure) to delete a registration
                string commandText = "usp_DeleteRegistration";

                // Create a new SqlCommand object and pass the command text and connection object
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);

                // Set the command type to stored procedure
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add parameters to the SqlCommand object
                sqlCommand.Parameters.AddWithValue("@RegistrationId", registrationId);

                // Open the connection
                conn.Open();

                // Execute the SQL query
                int rowsAffected = sqlCommand.ExecuteNonQuery();

                // Close the connection
                conn.Close();

                // If the number of rows affected is greater than 0, return true
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
