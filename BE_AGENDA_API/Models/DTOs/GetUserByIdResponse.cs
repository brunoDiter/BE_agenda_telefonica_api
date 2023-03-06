namespace BE_AGENDA_API.Models.DTOs
{
    public class GetUserByIdResponse
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }

    }
}
