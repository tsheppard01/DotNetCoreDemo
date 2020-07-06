using System;
using System.Security.Policy;

namespace DotNetCoreWebApp.Models
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
        }

        public int Id { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string DateOfBirth { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string EmailAddress { get; set; }

        public string Username { get; set; }
    }
}
