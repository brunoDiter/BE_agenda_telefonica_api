using BE_AGENDA_API.Data.Repository;
using BE_AGENDA_API.Entities;
using BE_AGENDA_API.Models.DTOs;
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

        [HttpGet]
        [Route("{Id}")]

        public IActionResult GetOneById(int Id) /* Metodo para traer un User por ID */

        {
            User user = _userRepository.GetById(Id);

            GetUserByIdResponse dto = new GetUserByIdResponse()
            {
                Name = user.Name,
                Email = user.Email,
                LastName = user.LastName,
                UserName = user.UserName,
            };
            try
            {
                return Ok(dto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateUser(UserForCreationDTO userDTO) /* Metodo para agregar un usuario */
        {
            _userRepository.CreateUser(userDTO);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                if (_userRepository.GetById(id).Name == "admin") /* Solo el admin, puede hacer delete a un Usuario. */
                {
                    _userRepository.Delete(id);
                }
                else
                {
                    _userRepository.Archive(id);
                }

                return StatusCode(204);
           
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        

        
    }
}
