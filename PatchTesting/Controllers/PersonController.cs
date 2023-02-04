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

        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            return Ok(People);
        }

        [HttpPatch("{id}")]
        public IActionResult JsonPatchWithModelState(int id, [FromBody] JsonPatchDocument<Person> patchDoc)
        {
            var person = People.FirstOrDefault(c => c.Id == id);
            //Automaticly update only the values that were sent in the patch obj
            patchDoc.ApplyTo(person);

            return Ok(person);
        }
    }
}