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
using DotNetCoreWebApp.services.Data;

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
            var model = new PersonViewModel()
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
        public async Task<IActionResult> Add(PersonViewModel personViewModel)
        {
            var person = new AddPersonRequest()
            {
                Forename = personViewModel.Forename,
                Surname = personViewModel.Surname,
                DateOfBirth = personViewModel.DateOfBirth,
                AddressLine1 = personViewModel.AddressLine1,
                AddressLine2 = personViewModel.AddressLine2,
                City = personViewModel.City,
                EmailAddress = personViewModel.EmailAddress,
                Username = personViewModel.Username
            };
            
            var id = await _personService.AddPerson(person);

            return RedirectToAction("Index", "Person");
        }
    }
}
