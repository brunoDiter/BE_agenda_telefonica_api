using BE_AGENDA_API.Data.Repository;
using BE_AGENDA_API.DTOs;
using BE_AGENDA_API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

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

        //[HttpGet]
        //[Route("{Id}")]

        //public IActionResult GetOneById( int Id) /* Metodo para traer un User por ID */
        //{
        //    try
        //    {
        //        return Ok(_userRepository.GetById(Id));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost]
        public IActionResult CreateUser(UserForCreationDTO userDTO) /* Metodo para agregar un usuario */
        {
            _userRepository.CreateUser(userDTO);
            return NoContent();
        }

        

        
    }
}
