using BE_AGENDA_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_AGENDA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public static List<Contact> FakeContact = new List<Contact>()
        {
            new Contact()
            {
                Id = 1,
                Name = "HAISDA",
                LastName ="ASDA",
                CelularNumber= 3412799201,
                TelephoneNumber = 4610399,
                Email = "asdas@asd.com",
                birthday = "21/09/1990"
            },
            new Contact()
            {
                Id = 2,
                Name = "HAISDA",
                LastName ="ASDA",
                CelularNumber= 3412799201,
                TelephoneNumber = 4610399,
                Email = "asdas@asd.com",
                birthday = "21/09/1990"
            },
            new Contact()
            {
                Id = 3,
                Name = "HAISDA",
                LastName ="ASDA",
                CelularNumber= 3412799201,
                TelephoneNumber = 4610399,
                Email = "asdas@asd.com",
                birthday = "21/09/1990"
            },
            new Contact()
            {
                Id = 4,
                Name = "HAISDA",
                LastName ="ASDA",
                CelularNumber= 3412799201,
                TelephoneNumber = 4610399,
                Email = "asdas@asd.com",
                birthday = "21/09/1990"
            }

        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(FakeContact);
        }
    }
}
