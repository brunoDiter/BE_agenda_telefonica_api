using BE_AGENDA_API.Entities;
using BE_AGENDA_API.Repository;
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
        [Route("getOne/{Id}")]
        public IActionResult GetOneById(int Id) /* Metodo para traer un User por ID */
        {
            List<Contact> ContactToReturn = _contactRepository.GetAllContacts();
            ContactToReturn.Where(x => x.Id == Id).ToList();
            if (ContactToReturn.Count > 0)
                return Ok(ContactToReturn);
            return BadRequest("Contacto inexistente");
        }

    }
}
