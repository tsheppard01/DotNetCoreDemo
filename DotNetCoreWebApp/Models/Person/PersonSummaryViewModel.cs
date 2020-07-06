using System;

namespace DotNetCoreWebApp.Models
{
    public class PersonSummaryViewModel
    {
        public PersonSummaryViewModel()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
    }
}
