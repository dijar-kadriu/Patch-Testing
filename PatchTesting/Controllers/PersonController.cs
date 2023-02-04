using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace PatchTesting.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        public static List<Person> People = new()
        {
            new()
            {
                Id =1,
                FirstName = "Dijar",
                LastName ="Kadriu",
                Age = 24,
                Birthdate = DateTime.UtcNow.AddYears(-24),
                Hobbies = new(){"Dota2","CSGO"},
                Pets = new  ()
                {
                    new(){Name="Bubi", Type ="Dog"}
                }
            },
             new()
            {
                 Id =2,
                FirstName = "Cooler Dijar",
                LastName ="Kadriu",
                Age = 24,
                Birthdate = DateTime.UtcNow.AddYears(-24)
            }

        };

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            return Ok(People);
        }

        [HttpPatch("{id}")]
        public IActionResult JsonPatchWithModelState(int id, [FromBody] JsonPatchDocument<Person> patchDoc)
        {
            var person = People.FirstOrDefault(c => c.Id == id);

            patchDoc.ApplyTo(person);

            return Ok(People);
        }
    }
}