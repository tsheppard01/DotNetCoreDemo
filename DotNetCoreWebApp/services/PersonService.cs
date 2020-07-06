using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebApp.Repositories;
using DotNetCoreWebApp.Repositories.Entities;
using DotNetCoreWebApp.Services.Data;

namespace DotNetCoreWebApp.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<Person> GetPerson(int id)
        {
            return _personRepository.GetPerson(id);
        }

        public async Task<IEnumerable<GetPersonSummaryResponse>> GetAllPersonsSummaries()
        {
            var persons = await _personRepository.GetAll();
            var summaries = persons.Select(
                p => new GetPersonSummaryResponse()
                {
                    Id = p.Id,
                    Name = p.Forename + " " + p.Surname,
                    Dob = p.Dob
                });
            return summaries;
        }

        public Task<int> AddPerson(Person person)
        {
            return _personRepository.AddPerson(person);
        }
    }
}
