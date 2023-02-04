using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace PatchTesting
{
    public class Person
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int? Age { get; set; }

        public DateTime? Birthdate { get; set; }

        public List<string> Hobbies { get; set; }

        public List<Pet> Pets { get; set; }

    }

    public class Pet
    {
        public string? Name { get; set; }

        public string? Type { get; set; }
    }
}