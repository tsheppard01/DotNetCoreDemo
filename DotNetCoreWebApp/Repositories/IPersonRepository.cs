using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DotNetCoreWebApp.Repositories.Entities;

namespace DotNetCoreWebApp.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetPerson(int id);

        Task<IEnumerable<Person>> GetAll();

        Task<int> AddPerson(Person person);
    }
}
