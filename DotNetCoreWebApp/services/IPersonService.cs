using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreWebApp.Repositories.Entities;
using DotNetCoreWebApp.Services.Data;

namespace DotNetCoreWebApp.Services
{
    public interface IPersonService
    {
        public Task<Person> GetPerson(int id);

        public Task<IEnumerable<GetPersonSummaryResponse>> GetAllPersonsSummaries();

        public Task<int> AddPerson(Person person);
    }
}
