using System;
using System.Security.Policy;

namespace DotNetCoreWebApp.Models
{
    public class PersonsViewModel
    {
        public PersonsViewModel()
        {
        }

        public int Id { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string DateOfBirth { get; set; }
    }
}
