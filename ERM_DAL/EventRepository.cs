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
                foreach (DataRow row in dt.Rows)
                {
                    // Create a new Event object
                    Event e = new Event();

                    // Set the properties of the Event object
                    e.EventId = Convert.ToInt32(row["EventId"]);
                    e.Name = row["Name"].ToString();
                    e.Date = Convert.ToDateTime(row["Date"]);
                    e.Location = row["Location"].ToString();
                    e.Description = row["Description"].ToString();

                    // Add the Event object to the list
                    events.Add(e);
                }

                // Return the list of events
                return events;
            }
        }

        // Now, go to EventService.cs and implement the GetAllEvents method
    }
}
