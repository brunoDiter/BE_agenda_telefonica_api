using BE_AGENDA_API.Data.Repository;
using BE_AGENDA_API.Entities;
using BE_AGENDA_API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_AGENDA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactRepository _contactRepository { get; set; }

        public ContactController(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet] /* Metodo para traer todos los Users */
        public IActionResult GetAll()
        {
            return Ok(_contactRepository.GetAllContacts());
        }


        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetOneById(int Id)
        {
            Contact contact = _contactRepository.GetById(Id);

            GetContactByIdResponse dto = new GetContactByIdResponse()
            {
                Name = contact.Name,
                CelularNumber = contact.CelularNumber,
                LastName = contact.LastName,
                TelephoneNumber = contact.TelephoneNumber,
                Email = contact.Email,
                Description = contact.Description
            };
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        public IActionResult createContact (ContactForCreationDTO contactDTO)
        {
            _contactRepository.createContact(contactDTO);
            return NoContent();

        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            _contactRepository
        }
        

    }
}
