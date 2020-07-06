using System;

namespace DotNetCoreWebApp.Services.Data
{
    public class GetPersonSummaryResponse
    {
        public GetPersonSummaryResponse()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
    }
}
