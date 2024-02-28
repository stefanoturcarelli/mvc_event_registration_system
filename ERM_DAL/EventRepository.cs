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
                // ADO.NET will fire the SQL query using the SqlCommand object
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            }
        }
    }
}
