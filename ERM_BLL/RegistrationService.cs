using ERM_DAL;
using ERM_ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM_BLL
{
    public class RegistrationService
    {
        // Create a method to get all registrations from a specific EventId
        public List<Registration> GetAllRegistrations(int eventId)
        {
            // Create a list of registrations
            List<Registration> registrations = new List<Registration>();

            // Create a new instance of RegistrationRepository
            RegistrationRepository registrationRepository = new RegistrationRepository();

            // Call the GetAllRegistrations method of RegistrationRepository and pass the eventId
            registrations = registrationRepository.GetAllRegistrations(eventId);

            // Get the list of registrations from the repository
            return registrations;
        }
        // Now, go the RegistrationController.cs file

        public List<Registration> GetAllRegistrations()
        {
            // Create a list of registrations
            List<Registration> registrations = new List<Registration>();

            // Create a new instance of RegistrationRepository
            RegistrationRepository registrationRepository = new RegistrationRepository();

            // Call the GetAllRegistrations method of RegistrationRepository
            registrations = registrationRepository.GettAllRegistrations();

            // Get the list of registrations from the repository
            return registrations;
        }

        // Create a method to add a new registration
        public bool AddRegistrationService(Registration registration)
        {
            // Create a new instance of RegistrationRepository
            RegistrationRepository registrationRepository = new RegistrationRepository();

            // Call the AddRegistration method of RegistrationRepository and pass the registration object
            return registrationRepository.AddRegistration(registration);
        }
        // Now, go the RegistrationController.cs file

        // Create a method to update a registration
        public bool UpdateRegistrationService(Registration registration)
        {
            // Create a new instance of RegistrationRepository
            RegistrationRepository registrationRepository = new RegistrationRepository();

            // Call the UpdateRegistration method of RegistrationRepository and pass the registration object
            return registrationRepository.UpdateRegistration(registration);
        }
        // Now, go the RegistrationController.cs file

        // Create a method to delete a registration
        public bool DeleteRegistrationService(int registrationId)
        {
            // Create a new instance of RegistrationRepository
            RegistrationRepository registrationRepository = new RegistrationRepository();

            // Call the DeleteRegistration method of RegistrationRepository and pass the registrationId
            return registrationRepository.DeleteRegistration(registrationId);
        }
        // Now, go the RegistrationController.cs file
    }
}
