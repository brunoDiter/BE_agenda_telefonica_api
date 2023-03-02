using System.ComponentModel.DataAnnotations;

namespace BE_AGENDA_API.DTOs
{
    public class AuthenticationRequestBody
    {
        [MaxLength(200)]
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
