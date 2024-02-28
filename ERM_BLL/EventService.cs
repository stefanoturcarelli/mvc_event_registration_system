using ERM_DAL;
using ERM_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM_BLL
{
    /// <summary>
    /// EventService is a service class that connects to the EventRepository and performs CRUD operations on Event table.
    /// </summary>
    public class EventService
    {

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();

            // Create an instance of EventRepository
            EventRepository eR = new EventRepository();

            // Call the GetAllEvents method of EventRepository to get all events
            events = eR.GetAllEvents();

            return events;
        }
        // Now, go to EventController.cs and implement inside the Index method the code to get all events from the database using EventService.

        public bool AddEventService(Event e)
        {
            // Create an instance of EventRepository
            EventRepository eR = new EventRepository();

            // Call the AddEvent method of EventRepository to add an event
            return eR.AddEvent(e);
        }
        // Now, go to EventController.cs and implement inside the Create method the code to add an event to the database using EventService.
    }
}
