using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Data;
using Logic;
using Entity;
using pulsaciones.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pulsaciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        public PersonController(PulsationsContext context)
        {
            _personService = new PersonService(context);
        }
        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<PersonViewModel> Get()
        {
            var persons = _personService.CheckAll().Select(p => new PersonViewModel(p));
            return persons;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(string id)
        {
            var person = _personService.Consult(id);
            if (person != null)
            {
                return Ok(person);
            }
            else
            {
                return NotFound();
            }
            
        }

        // POST api/<PersonController>
        [HttpPost]
        public ActionResult<PersonViewModel> Post(PersonInputModel personInput)
        {
            Person person = MapPerson(personInput);
            var response = _personService.Save(person);
            if (response.Error)
            {
                return BadRequest(response.Message);
            }
            else
            {
                return Ok(response.Person);
            }
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public ActionResult<String> Delete(string id)
        {
            string message = _personService.Delete(id);
            return Ok(message);
        }

        public Person MapPerson(PersonInputModel personInput)
        {
            var person = new Person()
            {
                Id = personInput.Id,
                Name = personInput.Name,
                Age = personInput.Age,
                Gender = personInput.Gender
            };
            return person;
        }
    }
}
