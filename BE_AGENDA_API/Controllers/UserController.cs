using BE_AGENDA_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_AGENDA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> FakeUsers = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email= "bruno@asdas.com",
                Name ="Bruno",
                Password = "contraseñasegura"
            },
            new User()
            {
                Id=2,
                Email= "eli@asdas.com",
                Name ="Eliana",
                Password = "contraseñasegura"
            },
            new User()
            {
                Id=3,
                Email= "perla@asdas.com",
                Name ="Perla",
                Password = "contraseñasegura"
            },
            new User()
            {
                Id=4,
                Email= "sandra@asdas.com",
                Name ="Sandra",
                Password = "contraseñasegura"
            }

        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(FakeUsers);
        }

        [HttpGet]
        [Route("getOne/{Id}")]

        public IActionResult GetOneById( int Id)
        {
            return Ok(FakeUsers.Where(x => x.Id == Id).ToList());
        }

    }
}
