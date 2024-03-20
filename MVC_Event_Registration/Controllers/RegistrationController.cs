using ERM_BLL;
using ERM_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            TempData.Keep();

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
            var events = new EventService().GetAllEvents();

            ViewBag.Events = events;

            return View();
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
            // Create a new instance of RegistrationService
            RegistrationService registrationService = new RegistrationService();

            // Fetch all registrations and use LINQ to get the registration with the specified id
            var specificRegistration = registrationService.GetAllRegistrations(id).Find(r => r.RegistrationId == id);

            // Pass the registration to the view
            return View(specificRegistration);
        }

        // POST: Registration/Edit/5
        [HttpPost]
        public ActionResult Edit(Registration r)
        {
            try
            {
                // TODO: Add update logic here

                // Create a new instance of RegistrationService
                RegistrationService registrationService = new RegistrationService();

                // Call the UpdateRegistrationService method of RegistrationService and pass the registration object
                bool result = registrationService.UpdateRegistrationService(r);
                if (result)
                {
                    ViewBag.Message = "Registration updated successfully";
                    return View();
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

        // GET: Registration/Delete/5
        public ActionResult Delete(int registrationId)
        {
            // Create a new instance of RegistrationService
            RegistrationService registrationService = new RegistrationService();

            int eventId = (int)TempData["EventId"];

            var specificRegistration = registrationService.GetAllRegistrations(eventId).Find(r => r.RegistrationId == registrationId);

            // Call the DeleteRegistrationService method of RegistrationService and pass the registrationId
            if (registrationService.DeleteRegistrationService(registrationId, specificRegistration.EventId))
            {
                return RedirectToAction("Index", new { eventId = eventId });
            }

            return null;
        }
    }
}
