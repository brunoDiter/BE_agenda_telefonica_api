using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_AGENDA_API.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] /*Se encarga de autogenerar un ID automaticamente */
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string Password { get; set; }

        public ICollection<Contact>? Contact { get; set; }
    }
}
