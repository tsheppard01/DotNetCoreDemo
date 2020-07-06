using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebApp.Models;
using DotNetCoreWebApp.Repositories.Entities;
using DotNetCoreWebApp.Services;

namespace DotNetCoreWebApp.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allPersons = await _personService.GetAllPersonsSummaries();
            var model = allPersons.Select(
                p => new PersonSummaryViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    DateOfBirth = p.Dob
                });

            return View(model);
        }

        [HttpGet("Person/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var person = await _personService.GetPerson(id);
            var model = new PersonsViewModel()
            {
                Id = person.Id,
                Forename = person.Forename,
                Surname = person.Surname,
                DateOfBirth = person.Dob
            };

            return View("Person", model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonsViewModel personsViewModel)
        {
            var person = new Person()
            {
                Forename = personsViewModel.Forename,
                Surname = personsViewModel.Surname,
                Dob = personsViewModel.DateOfBirth,
                AddressLine1 = "N",
                AddressLine2 = "N",
                City = "N"
            };
            
            var id = await _personService.AddPerson(person);

            return RedirectToAction("Index", "Person");
        }
    }
}
