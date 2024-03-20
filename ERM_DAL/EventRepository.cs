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
    /// <summary>
    /// EventRepository connects to the database and performs CRUD operations on Event table.
    /// </summary>
    public class EventRepository
    {
        public List<Event> GetAllEvents()
        {
            // Create a list of events
            List<Event> events = new List<Event>();

            // Connect to the database and get all events with "using" statement
            // The "using" statement ensures that the connection is closed when the code block exits
            // Inside parantheses, we create a new SqlConnection object and pass the connection string
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                // Fire a SQL query (Stored Procedure) to get all events
                string commandText = "usp_GetAllEvents";

                // Create a new SqlCommand object and pass the command text and connection object
                SqlCommand sqlCommand = new SqlCommand(commandText, conn);

                // Set the command type to stored procedure
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Use SqlDataAdapter to fill the data from the database into a DataTable
                // SqlDataAdapter is a part of ADO.NET data provider
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                // Create a new DataTable object
                // At this point, the DataTable is empty
                DataTable dt = new DataTable();

                // At this point, the SqlDataAdapter will fire the SQL query and fill the DataTable with the data
                adapter.Fill(dt);

                // Convert ADO.NET DataTable to List of Event objects
                // Loop through each row in the DataTable
                foreach (DataRow dr in dt.Rows)
                {
                    events.Add(
                            new Event
                            {
                                EventId = Convert.ToInt32(dr["EventId"]),
                                Name = Convert.ToString(dr["Name"]),
                                Location = Convert.ToString(dr["Location"]),
                                Date = Convert.ToDateTime(dr["Date"]),
                                Description = Convert.ToString(dr["Description"]),
                            });
                }

                // Return the list of events
                return events;
            }
        }
        // Now, go to EventService.cs and implement the GetAllEvents method

        public bool AddEvent(Event e)
        {

            // Connect to the database and add an event with "using" statement
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                // Fire a SQL query (Stored Procedure) to add an event
                SqlCommand sqlCommand = new SqlCommand("usp_AddEvent", conn);

                // Set the command type to stored procedure
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                sqlCommand.Parameters.AddWithValue("@Name", e.Name);
                sqlCommand.Parameters.AddWithValue("@Date", e.Date);
                sqlCommand.Parameters.AddWithValue("@Location", e.Location);
                sqlCommand.Parameters.AddWithValue("@Description", e.Description);

                // Open the connection
                conn.Open();

                // Execute the command
                int rowsAffected = sqlCommand.ExecuteNonQuery();

                // Close the connection
                conn.Close();

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
        // Now, go to EventService.cs and implement the AddEvent method

        public bool DeleteEvent(int eventId)
        {
            // Connect to the database and delete an event with "using" statement
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                // Fire a SQL query (Stored Procedure) to delete an event
                SqlCommand sqlCommand = new SqlCommand("usp_DeleteEvent", conn);

                // Set the command type to stored procedure
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                sqlCommand.Parameters.AddWithValue("@EventId", eventId);

                // Open the connection
                conn.Open();

                // Execute the command
                int rowsAffected = sqlCommand.ExecuteNonQuery();

                // Close the connection
                conn.Close();

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
        // Now, go to EventService.cs and implement the DeleteEvent method

        public bool UpdateEvent(Event e)
        {
            // Connect to the database and update an event with "using" statement
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
            {
                // Fire a SQL query (Stored Procedure) to update an event
                SqlCommand sqlCommand = new SqlCommand("usp_UpdateEvent", conn);

                // Set the command type to stored procedure
                sqlCommand.CommandType = CommandType.StoredProcedure;

                // Add parameters to the stored procedure
                sqlCommand.Parameters.AddWithValue("@EventId", e.EventId);
                sqlCommand.Parameters.AddWithValue("@Name", e.Name);
                sqlCommand.Parameters.AddWithValue("@Date", e.Date);
                sqlCommand.Parameters.AddWithValue("@Location", e.Location);
                sqlCommand.Parameters.AddWithValue("@Description", e.Description);

                // Open the connection
                conn.Open();

                // Execute the command
                int rowsAffected = sqlCommand.ExecuteNonQuery();

                // Close the connection
                conn.Close();

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
        // Now, go to EventService.cs and implement the UpdateEvent method
    }
}
