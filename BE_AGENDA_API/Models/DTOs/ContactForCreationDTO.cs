using System.ComponentModel.DataAnnotations;

namespace BE_AGENDA_API.Models.DTOs
{
    public class ContactForCreationDTO
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public string LastName { get; set; }
        public long CelularNumber { get; set; }
        public long TelephoneNumber { get; set; }
        public string Email { get; set; }
    }
}
