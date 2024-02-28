using ERM_BLL;
using ERM_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Event_Registration.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            // Create an instance of EventService
            EventService eventService = new EventService();

            // Call the GetAllEvents method of EventService to get all events
            var events = eventService.GetAllEvents();

            // Pass the list of events to the view
            return View(events);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(Event e)
        {
            try
            {
                // TODO: Add insert logic here

                // Create an instance of EventService
                EventService eventService = new EventService();

                // Call the AddEvent method of EventService to add an event
                if (eventService.AddEventService(e))
                {
                    ViewBag.Message = "Event added successfully";
                    return View();
                    //return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
