using ERM_BLL;
using ERM_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Event_Registration.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index(int eventId)
        {
            // Create a new instance of RegistrationService
            RegistrationService registrationService = new RegistrationService();

            // Call the GetAllRegistrations method of RegistrationService and pass the eventId
            var registrations = registrationService.GetAllRegistrations(eventId);

            // We use TempData to pass the eventId to the view
            TempData["EventId"] = eventId;

            return View(registrations);
        }

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
            // Create a null Registration object
            Registration registration = null;

            // We use TempData to pass the eventId to the view
            int eventId = (int)TempData["EventId"];

            // If the eventId is not 0, then create a new Registration object
            if (eventId != 0)
            {
                // Create a new Registration object
                registration = new Registration()
                {
                    // Set the EventId and RegistrationDate properties
                    EventId = eventId,
                    // Set the RegistrationDate property to the current date and time
                    RegistrationDate = null
                };
            }

            // Pass the Registration object to the view
            return View(registration);
        }

        // POST: Registration/Create
        [HttpPost]
        public ActionResult Create(Registration registration)
        {
            try
            {
                // TODO: Add insert logic here
                // Create a new instance of RegistrationService
                RegistrationService registrationService = new RegistrationService();

                // Call the AddRegistrationService method of RegistrationService and pass the registration object
                bool result = registrationService.AddRegistrationService(registration);

                // If the result is true, redirect to the Index action method of the RegistrationController
                if (result)
                {
                    return RedirectToAction("Index", new { eventId = registration.EventId });
                }
                else
                {
                    return View(registration);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registration/Edit/5
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

        // GET: Registration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registration/Delete/5
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
