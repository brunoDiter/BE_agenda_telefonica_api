using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BE_AGENDA_API.Models.DTOs.Enum.States;

namespace BE_AGENDA_API.Entities
{
    public class Contact
    {
        [Key] /* Indico cual es la key */
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long CelularNumber { get; set; }
        public long? TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public State State { get; set; } = State.Active; /* Creo un state, para poder hacer un delete logico. */


        [ForeignKey ("UserId")] /* Indico cual va a ser la clave foranea, indicandole el nombre.*/
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
