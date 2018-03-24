using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace team7WebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}