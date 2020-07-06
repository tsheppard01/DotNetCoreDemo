using System;
using System.Collections.Generic;

namespace DotNetCoreWebApp.Repositories.Entities
{
    public partial class Person
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Dob { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
