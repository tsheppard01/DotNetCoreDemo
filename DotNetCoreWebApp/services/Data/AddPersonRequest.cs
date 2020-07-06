using System;
namespace DotNetCoreWebApp.services.Data
{
    public class AddPersonRequest
    {
        public AddPersonRequest()
        {
        }

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
