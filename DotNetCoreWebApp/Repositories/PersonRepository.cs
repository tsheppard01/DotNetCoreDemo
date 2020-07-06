using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetCoreWebApp.Repositories.Entities;

namespace DotNetCoreWebApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DemoApplicationContext _dbContext;

        public PersonRepository(DemoApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Person> GetPerson(int id)
        {
            return await _dbContext.Person.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _dbContext.Person.ToListAsync();
        }

        public async Task<int> AddPerson(Person person)
        {
            _dbContext.Add(person);
            await _dbContext.SaveChangesAsync();
            return person.Id;
        }
    }
}
