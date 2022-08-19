using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOL_LUIS_ROJAS.WEB.ViewModels
{
    public class UserViewModel
    {
        public int? Id { get; set; }

        public string DNI { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool Status { get; set; }

        public string Role { get; set; }
    }
}