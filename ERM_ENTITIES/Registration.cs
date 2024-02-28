using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERM_ENTITIES
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public int EventId { get; set; }
        public string AttendeeFirstName { get; set; }
        public string AttendeeLastName { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
