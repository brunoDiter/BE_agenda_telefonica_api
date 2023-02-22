using BE_AGENDA_API.Entities;
using BE_AGENDA_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_AGENDA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepository { get; set; }
        public UserController(UserRepository userRepository) /* Contructor de la clase */
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAllUsers());
        }

        [HttpGet]
        [Route("getOne/{Id}")]

        public IActionResult GetOneById( int Id) /* Metodo para traer un User por ID */
        {
            List<User> UserToReturn = _userRepository.GetAllUsers();
            UserToReturn.Where(x => x.Id == Id).ToList();
            if (UserToReturn.Count > 0)
                return Ok(UserToReturn);
            return BadRequest("Usuario inexistente");
        }

    }
}
